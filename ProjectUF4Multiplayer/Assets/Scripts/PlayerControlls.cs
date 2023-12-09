using Unity.Netcode;
using UnityEngine;

public class PlayerControlls : NetworkBehaviour
{
    
    
    public delegate void StartGame();
    public StartGame startGameDelegate;
    
    
    private UnityEngine.Vector3 HostPosition;
    private UnityEngine.Vector3 ClientPosition;

    private bool startGame;

    [SerializeField]
    private NetworkVariable<UnityEngine.Color> color = new NetworkVariable<Color>();
    [SerializeField]
    private NetworkVariable<int> contadorTemps = new NetworkVariable<int>();
    private Rigidbody2D rigidBody;
    
    void Awake()
    {
        rigidBody= GetComponent<Rigidbody2D>(); 
        startGame = false; 
        HostPosition = new UnityEngine.Vector3(7f, 0,0);
        ClientPosition = new UnityEngine.Vector3(-7f, 0, 0);
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        //Debug.Log(color.Value.ToString());
        
        color.OnValueChanged += ChangeColor;
        if (IsServer)
        {
            
            
            //ChangeColorClientRpc();
            switch (OwnerClientId)
            {
                case 0:
                    color.Value = Color.red; break;
                default:
                    color.Value = Color.blue; break;

            }
            //changeColorClientRpc();
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color.Value;

        if (!IsOwner) return;

        if (IsHost)
        {
            transform.position = HostPosition;
            //transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        }else if (IsClient)
        {
            startGameDelegate?.Invoke();
            startGame = true;
            ChangePositionServerRpc(ClientPosition);
        }
    }
    void Update()
    {
        if(!IsOwner) return;

        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color.Value;
        UnityEngine.Vector3 vector = new UnityEngine.Vector3(0, 0, 0);
        
        if(Input.GetKey(KeyCode.W))
        {
            vector.y += 100f;
            
        }else if(Input.GetKey(KeyCode.S))
        {
            vector.y -= 100f;
        }

        if (IsHost && startGame)
        {
            rigidBody.velocity = (vector * Time.deltaTime).normalized;
        }else if(IsClient)
        {
            MoveCharacterPhysicsServerRpc(vector);
        }
    }
    [ServerRpc]
    private void MoveCharacterPhysicsServerRpc(UnityEngine.Vector3 velocity, ServerRpcParams serverRpcParams = default)
    {
        rigidBody.velocity = (velocity * Time.deltaTime).normalized;
    }

    [ServerRpc]
    private void ChangePositionServerRpc(UnityEngine.Vector3 position, ServerRpcParams serverRpcParams = default)
    {
        transform.position = position;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;

    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        color.OnValueChanged -= ChangeColor;
    }

    private void ChangeColor(Color oldValue, Color newValue)
    {
        ChangeColorClientRpc();
    }
    [ClientRpc]
    public void ChangeColorClientRpc()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        if (IsOwner)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}

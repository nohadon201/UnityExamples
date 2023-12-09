using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clint : MonoBehaviour
{
    [SerializeField]
    private int spd;

    public ClientSO data;
    // Start is called before the first frame update
    void Awake()
    {
        this.data.posicioInicial=this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move -= Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= Vector2.right;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right;
        }else if(Input.GetKeyDown(KeyCode.P))
        {
            CanviDia();
            
        }

        this.GetComponent<Rigidbody2D>().velocity = move.normalized*spd;
    }
    public void CanviDia(){
        this.transform.position=this.data.posicioInicial;
    }
}

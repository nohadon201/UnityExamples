using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private bool player;
    private Transform Transform;
    void Awake()
    {
        player=Player != null;
        Transform= Player.transform;    
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 finalPoint = new Vector3(Transform.position.x, Transform.position.y, this.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, finalPoint, Time.deltaTime * 3);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ControllsCamera : MonoBehaviour
{
    Camera camera;
    Rigidbody2D rb;
    [SerializeField] private float velocity = 10; 
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        velocity = velocity == 0 ? 20 : velocity;   
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) 
            rb.velocity = new Vector2(-velocity, 0);
        else if(Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(velocity, 0);
        else
            rb.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
            rb.velocity += new Vector2(0, velocity);
        else if (Input.GetKey(KeyCode.S))
            rb.velocity += new Vector2(0, -velocity);
        else
            rb.velocity += new Vector2(0, 0);

        camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * velocity;
    }
}

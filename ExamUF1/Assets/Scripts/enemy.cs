using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Vector3 target;
    private int speed;
    // Start is called before the first frame update
    void Awake()
    {
        
        transform.position = new Vector3(Random.Range(-10,10), Random.Range(5,5),0);
        speed = 3;
        target = new Vector3(0, 0, 0);
        Vector3 vec = (target - transform.position);
        vec.Normalize();
        this.GetComponent<Rigidbody2D>().velocity = vec * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}

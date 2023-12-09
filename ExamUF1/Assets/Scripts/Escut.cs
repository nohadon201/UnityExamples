using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escut : MonoBehaviour
{
    public delegate void escutHandle();
    public event escutHandle escutResta;
    // Start is called before the first frame update
    private int health;
    public UIData data;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && this.data.health_escut>0)
        {
            Destroy(collision.gameObject);
            
            escutResta.Invoke();
        }
    }
}

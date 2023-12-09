using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espia : MonoBehaviour
{
    [SerializeField]
    private Camera cameraAltern;
    private bool documents = false;
    private bool camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera= false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && camera)
        {
            print("Q a la sala de cameres");
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
            cameraAltern.gameObject.SetActive(!cameraAltern.gameObject.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sala Cameres")
        {
            this.camera = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Sala Cameres")
        {
            this.camera = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Espia: " + collision.transform.tag);
        if (collision.transform.tag == "guardia")
        {
            this.gameOver();
        }
        if (collision.transform.tag == "powerup")
        {
            print("He agafat els documents!");
            Destroy(collision.transform.gameObject);
            documents = true;
        }
        

    }


    public void gameOver()
    {
        print("Game over");
        Destroy(this.gameObject);
    }
}

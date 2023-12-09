using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    [SerializeField] private PlayerData data;
    public PlayerData Data { get => data; private set => data = value; }
    
    public static Player Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void onTri(Collision2D collision)
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CombatTrigger")
        {
            GetComponent<PlayerInput>().enabled = false;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            SceneManager.LoadScene("Combat");
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puerta" || collision.gameObject.tag == "Cofre")
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<TriggerObjectScript>().triggering();
            }
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        GetComponent<Rigidbody2D>().velocity =(context.ReadValue<Vector2>() * Clamp(100000000,2,10));

    }
    public static int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public bool Active;
    private bool izquierda;
    // Start is called before the first frame update
    void Start()
    {
        izquierda = transform.position.x < 0;
        if (Active)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            spawn_function();
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            if (izquierda)
            {
                if (transform.GetChild(a).gameObject.activeSelf && transform.GetChild(a).gameObject.transform.position.x > transform.position.x + 20)
                {
                    transform.GetChild(a).gameObject.SetActive(false);
                }
            }
            else
            {
                if (transform.GetChild(a).gameObject.activeSelf && transform.GetChild(a).gameObject.transform.position.x < transform.position.x - 20)
                {
                    transform.GetChild(a).gameObject.SetActive(false);
                }
            }
            

        }
    }
    public void spawn_function() { 
        
        for (int a = 0; a < transform.childCount; a++)
        {
            if (!transform.GetChild(a).gameObject.activeSelf)
            {
                transform.GetChild(a).gameObject.transform.position=transform.position;
                transform.GetChild(a).gameObject.SetActive(true);
                if (izquierda)
                {
                    transform.GetChild(a).gameObject.GetComponent<Rigidbody2D>().AddTorque(-2000);
                }
                else
                {
                    transform.GetChild(a).gameObject.GetComponent<Rigidbody2D>().AddTorque(2000);
                }
                
                break;
            }

        }
    }
}

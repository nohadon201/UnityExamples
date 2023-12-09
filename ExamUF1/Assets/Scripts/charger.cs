using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charger : MonoBehaviour
{
    // Start is called before the first frame update
    public UIData data;
    void Awake()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.right*data.forçaRecàrrega);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10)
        {
            data.health_escut++;
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}

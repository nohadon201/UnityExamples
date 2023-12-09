using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controls_estrella : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 1);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -1);
        }
    }
    public void GameOver()
    {
        Destroy(this);
        SceneManager.LoadScene("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameOver();
        }
    }
}

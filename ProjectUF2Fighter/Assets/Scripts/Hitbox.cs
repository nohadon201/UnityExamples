using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            transform.parent.GetComponent<controls>().setJump(false);
        }else if(collision.gameObject.tag == "projectil")
        {
            collision.gameObject.SetActive(false);
            transform.parent.GetComponent<controls>().aserPupa();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != transform.parent.tag)
        {
            transform.parent.GetComponent<controls>().aserPupa();

        }
        {
            //this.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2())
        }
    }
}

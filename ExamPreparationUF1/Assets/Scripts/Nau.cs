using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nau : MonoBehaviour
{
    private Rigidbody2D fis;
    private GameObject pool;
    public NauData nauData;
    // Start is called before the first frame update
    void Awake()
    {
        pool = this.transform.GetChild(0).gameObject;
        fis = this.GetComponent<Rigidbody2D>();
        if (this.nauData.blanc)
        {
            this.GetComponent<SpriteRenderer>().sprite = this.nauData.nau_b;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = this.nauData.nau_n;
        }
    }

    // Update is called once per frame
    void Update()
    {
        controls();
    }
    public void controls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.fis.velocity = new Vector2(4,fis.velocity.y);
        }else if (Input.GetKey(KeyCode.A))
        {
            this.fis.velocity = new Vector2(-4, fis.velocity.y);
        }
        else
        {
            this.fis.velocity = new Vector2(0, fis.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            this.fis.velocity = new Vector2(fis.velocity.x, 4);
        }
        else if (Input.GetKey(KeyCode.S)){
            this.fis.velocity = new Vector2(fis.velocity.x, -4);
        }
        else
        {
            this.fis.velocity = new Vector2(fis.velocity.x,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparar();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            canvi_color();
        }
    }
    public void canvi_color()
    {
        if (this.nauData.blanc)
        {
            this.nauData.blanc = false;
            this.GetComponent<SpriteRenderer>().sprite = this.nauData.nau_n;
        }
        else
        {
            this.nauData.blanc = true;
            this.GetComponent<SpriteRenderer>().sprite = this.nauData.nau_b;
        }
    }
    public void disparar()
    {
        for(int a = 0; a < pool.transform.childCount; a++)
        {
            GameObject bullet = pool.transform.GetChild(a).gameObject;
            if (!bullet.activeSelf)
            {
                if (this.nauData.blanc)
                {
                    bullet.GetComponent<SpriteRenderer>().sprite = this.nauData.projecti_b;
                }
                else
                {
                    bullet.GetComponent<SpriteRenderer>().sprite = this.nauData.projectil_n;
                }
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6);
                break;
            }
        }
    }
}

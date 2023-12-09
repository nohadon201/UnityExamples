using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int vida_act;
    public NauData nauData;
    private GameObject pool;
    // Start is called before the first frame update
    void Awake()
    {
        this.pool = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.vida_act == 0)
        {
            Destroy(this);
        }
    }
    public void disparar()
    {
        int ind = 3;
        for(int a = 0; a < this.pool.transform.childCount; a++)
        {
            GameObject bullet = pool.transform.GetChild(a).gameObject;
            if (!bullet.activeSelf)
            {
                bullet.GetComponent<SpriteRenderer>().sprite = this.nauData.projecti_b;
                //bullet.GetComponent<Rigidbody2D>().SetRotation
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -6);
                ind--;
                if (ind == 0)
                {
                    break;
                } 
            }
        }
    }
    IEnumerator disparar_corrutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectil_nau")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == this.nauData.projectil_n)
            {
                this.vida_act--;
            }
        }
    }
}

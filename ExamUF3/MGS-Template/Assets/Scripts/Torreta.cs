using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public GameObject bala;
    private int spd = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dispar());
    }

    private IEnumerator dispar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            shoot();
        }
    }

    private void shoot()
    {
        GameObject newBala = Instantiate(bala);
        newBala.transform.position = this.transform.position;
        newBala.GetComponent<Rigidbody>().velocity = this.transform.up*spd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

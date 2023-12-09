using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolScript : MonoBehaviour
{
    private int Olejada;
    void Awake()
    {
        Olejada = 1;
        startSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startSpawn()
    {
        int ey = 0;
        for (int a = 0; a < transform.childCount;a++)
        {
            if(!transform.GetChild(a).gameObject.activeSelf && ey<=Olejada) {
                ey++;
                transform.GetChild(a).gameObject.SetActive(true);
                transform.GetChild(a).transform.position = this.transform.position;
                transform.GetChild(a).GetComponent<enemyScript>().currentState = StateEnemy.NONE;
            }
        }
    }
}

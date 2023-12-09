using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PoolS : MonoBehaviour
{
    [SerializeField]
    [DefaultValue(2f)]
    private float Cooldown;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(startSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Cooldown);
            for(int a = 0; a < transform.childCount; a++)
            {
                if (!transform.GetChild(a).gameObject.activeSelf)
                {
                    transform.GetChild(a).gameObject.SetActive(true);
                    transform.GetChild(a).transform.position=this.transform.position;
                    transform.GetChild(a).GetComponent<Rigidbody>().AddForce(new Vector3(2000,0,0));
                    break;
                }
            }
        }
    }
}

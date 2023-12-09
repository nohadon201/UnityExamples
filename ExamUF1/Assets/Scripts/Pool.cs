using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Pool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while (true)
        {
            for (int a = 0; a < transform.childCount; a++)
            {
                if (!transform.GetChild(a).gameObject.activeSelf)
                {
                    //GameObject projectil = transform.GetChild(a).gameObject;
                    //projectil.SetActive(true);
                    //projectil.transform.position = this.transform.position;
                    //Vector3 = new Vector3(0, 0, 0) - this.transform.position;
                    //projectil.GetComponent<Rigidbody2D>().velocity = target.transform.up * velocity;
                    //break;
                }

            }
            yield return new WaitForSeconds(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

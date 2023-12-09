using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{


    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            //Debug.Log("a "+transform.position.z);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3);
            if (transform.localPosition.z < -50f)
            {
                //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                gameObject.SetActive(false);
            }
        }
    }
}

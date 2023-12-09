using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMK1 : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 cameraPosition;
    bool alerta;
    // Start is called before the first frame update
    void Start()
    {
        alerta= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(alerta)
        {
            Vector3 direction = this.playerTransform.position - this.transform.position;
            direction.Normalize();
            RaycastHit raycastInfo;
            if(Physics.Raycast(transform.position,direction,out raycastInfo)){
                if (raycastInfo.transform.tag == "espia")
                {
                    GetComponent<NavMeshAgent>().SetDestination(raycastInfo.transform.position);
                }
                else
                {
                    GetComponent<NavMeshAgent>().SetDestination(this.cameraPosition);
                }
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(this.cameraPosition);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "espia")
        {
            collision.gameObject.GetComponent<Espia>().gameOver();
        }
    }
    public void AlertMK1(Transform t)
    {
        this.playerTransform= t;    
        this.cameraPosition = t.position;
        alerta= true;
    } 


}

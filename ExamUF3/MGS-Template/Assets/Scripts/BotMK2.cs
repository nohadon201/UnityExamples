using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMK2 : MonoBehaviour
{
    [SerializeField]
    private OnDetectionPlayer onDetectionPlayer;
    [SerializeField]
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<NavMeshAgent>().SetDestination(playerTransform.position);
        Vector3 direction = this.playerTransform.position - this.transform.position;
        direction.Normalize();
        //print(direction);
        RaycastHit raycastInfo;
        if (Physics.Raycast(transform.position, direction, out raycastInfo))
        {
            if (raycastInfo.transform.tag == "espia")
            {
               
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



}
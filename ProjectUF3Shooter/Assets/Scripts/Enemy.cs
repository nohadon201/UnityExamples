using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private Transform PlayerInfo;
    [SerializeField]
    private EnemyInfo myInfo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myInfo.lives <= 0)
        {
            gameObject.SetActive(false);    
        }else if (GetComponent<NavMeshAgent>().enabled)
        {
            this.GetComponent<NavMeshAgent>().destination = PlayerInfo.position;
        }
        

    }
    public void Hit()
    {
        myInfo.lives--;
    }
}

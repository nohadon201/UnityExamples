using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine.SocialPlatforms.Impl;

public class IAController : Agent
{
    public delegate void resetDelegator();
    public static resetDelegator resetPosition;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();    
    }
    // Update is called once per frame
    void Update()
    {
        controllRotationOfCamera();
        if(transform.position.z> 5000)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            resetPosition?.Invoke();
        }
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int a = (int) Mathf.Round(actions.ContinuousActions[0]);
        int b = (int)Mathf.Round(actions.ContinuousActions[1]);
        //Debug.Log(a+" "+b);
        if (a> 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(7, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }else if(a < 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-7, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        if (b > 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3( GetComponent<Rigidbody>().velocity.x, 5,GetComponent<Rigidbody>().velocity.z);
        }
        else if (b < 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, -5, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.y, 0, GetComponent<Rigidbody>().velocity.z);
        }
    }
    public override void OnEpisodeBegin()
    {
        score = 0;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            AddReward(-1f);
        }
    }

    public void controllRotationOfCamera()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.GetChild(0).transform.Rotate(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.GetChild(0).transform.Rotate(0, -1, 0);
        }
        else
        {
            transform.GetChild(0).transform.Rotate(0, 0, 0);
        }
    }
}

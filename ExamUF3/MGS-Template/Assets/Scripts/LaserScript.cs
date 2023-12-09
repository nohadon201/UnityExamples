using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private OnDetectionPlayer gameEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycastInfo;
        if(Physics.Raycast(transform.position, transform.forward, out raycastInfo))
        {
            if (raycastInfo.transform.tag == "espia")
            {
                gameEvent?.Raise(raycastInfo.transform);
            }
        }
    }
}

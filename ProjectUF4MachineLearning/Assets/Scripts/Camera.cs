using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    Vector3 currentTargetPos;
    [SerializeField]
    private Transform targetFollow;
    [SerializeField]
    private Transform targetLookAt;
    void Start()
    {
        if(targetFollow==null)
        {
            targetFollow = GameObject.Find("targetFollow").GetComponent<Transform>();
        }
        if (targetLookAt == null)
        {
            targetLookAt = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTargetPos = targetFollow.position;

        RaycastHit hit;
        if (Physics.Linecast(targetFollow.parent.position, targetFollow.position, out hit))
        {
            currentTargetPos = hit.point;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, currentTargetPos, Time.deltaTime * 5);
        transform.LookAt(targetLookAt.position);
        
    }

}

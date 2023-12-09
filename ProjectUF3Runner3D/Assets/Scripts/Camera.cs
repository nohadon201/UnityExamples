using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 targetPos;
    private Transform target;
    private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField][Range(0,1)] private float lerpValue;
    void Awake()
    {
        GameObject player = GameObject.Find("Sanic");
        this.target = player.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
        this.player = player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetPos = target.position;

        RaycastHit hit;
        if (Physics.Linecast(target.parent.position, target.position, out hit))
        {
            targetPos = hit.point;
        }
        CameraLerp(targetPos);

       
        transform.LookAt(player.position);
    }
    private void CameraLerp(Vector3 pos)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime*5);
        this.transform.LookAt(target.parent);
    }
}

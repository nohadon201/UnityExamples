using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    [SerializeField]    
    private Transform player;
    
    void Awake()
    {
        IAController.resetPosition += reset;
        StartCoroutine(StartSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z + 50);
        //Debug.Log("My position " + transform.position.z + " player position " + player.position.z);
    }
    public void reset()
    {
        StopCoroutine(StartSpawn());
        for (int a = 0; a < transform.childCount; a++)
        {
            if (transform.GetChild(a).gameObject.activeSelf)
            {
                transform.GetChild(a).gameObject.SetActive(false);
            }
        }
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z + 50);
        StartCoroutine(StartSpawn());
    }
    public GameObject SelectNextObstacle()
    {
        for(int a = 0; a < transform.childCount; a++)
        {
            if(!transform.GetChild(a).gameObject.activeSelf)
            {
                return transform.GetChild(a).gameObject;
            }
        }
        return null;
    }
    public void Spawn (GameObject gameObject)
    {
        if(gameObject != null)
        {
            float x = Random.Range(-50, 50f);
            float y = Random.Range(-3f, 3f);
            gameObject.transform.localPosition = new Vector3(x, y, transform.position.z);
            gameObject.SetActive(true);
        }

    }
    public IEnumerator StartSpawn()
    {
        while(true)
        {
            Spawn(SelectNextObstacle());
            yield return new WaitForSeconds(4f);
        }
    }
}

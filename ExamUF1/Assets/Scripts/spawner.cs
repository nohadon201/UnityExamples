using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class spawner : MonoBehaviour
{
    private Vector3 target;
    private int speed;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0, 0, 0);
        StartCoroutine(spawn());
    }
    public IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(enemy);
            yield return new WaitForSeconds(2);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

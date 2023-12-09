using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> naus =new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        naus = new List<GameObject>();
        StartCoroutine(spawn_enemy());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator spawn_enemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(3);
        }
        

    }
}

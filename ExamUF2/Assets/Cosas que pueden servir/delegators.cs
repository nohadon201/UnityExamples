using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegators : MonoBehaviour
{
    public delegate void cosa();
    public static cosa a;
    void Awake()
    {
        a?.Invoke();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

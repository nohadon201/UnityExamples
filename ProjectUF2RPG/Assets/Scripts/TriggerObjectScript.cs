using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectScript : MonoBehaviour
{
    [SerializeField] private TriggerObject triggerObject;
    void Awake()
    {
        if (!triggerObject.Triggered)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }
    public void triggering()
    {
        triggerObject.Triggered = true;
        this.gameObject.SetActive(false);
    }

}

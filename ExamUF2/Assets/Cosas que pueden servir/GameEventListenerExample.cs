using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerExample : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventExample Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<GameObject> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject it)
    {

        Response.Invoke(it);
    }

}

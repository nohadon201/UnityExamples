using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
[CreateAssetMenu]
public class GameEventExample : ScriptableObject
{
    private readonly List<GameEventListenerExample> gameEventListenerExamples= new List<GameEventListenerExample>();
    public void Raise(GameObject it)
    {
        for (int i = gameEventListenerExamples.Count - 1; i >= 0; i--)
            gameEventListenerExamples[i].OnEventRaised(it);
    }

    public void RegisterListener(GameEventListenerExample listener)
    {
        if (!gameEventListenerExamples.Contains(listener))
            gameEventListenerExamples.Add(listener);
    }

    public void UnregisterListener(GameEventListenerExample listener)
    {
        if (gameEventListenerExamples.Contains(listener))
            gameEventListenerExamples.Remove(listener);
    }

}

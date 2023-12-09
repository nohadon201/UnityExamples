using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ObstacleUpBeginAuthoring : MonoBehaviour
{
    public float velocity;
}
public class ObastacleUpBeginBaker : Baker<ObstacleUpBeginAuthoring>
{
    public override void Bake(ObstacleUpBeginAuthoring authoring)
    {
        //Debug.Log("bake");
        AddComponent(new ObstacleUpBeginComponent
        {
            velocity = authoring.velocity
        });
    }
}

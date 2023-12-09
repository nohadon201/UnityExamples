using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct ObstacleUpBeginAspect : IAspect
{
    private readonly Entity entity;
    private readonly RefRW<ObstacleUpBeginComponent> ObstacleUp;
    private readonly TransformAspect transformAspect;

    public void Move(float time)
    {
        transformAspect.WorldPosition += new Unity.Mathematics.float3(0, ObstacleUp.ValueRW.velocity * time, 0);
    }
    public void changeVelocity()
    {
        if (transformAspect.WorldPosition.y > 3f || transformAspect.WorldPosition.y < -3f)
        {
            ObstacleUp.ValueRW.velocity = ObstacleUp.ValueRW.velocity * -1;
        }
    }
}

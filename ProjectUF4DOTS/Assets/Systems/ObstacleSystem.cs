using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct ObstaclesSystem : Unity.Entities.ISystem
{

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        //throw new System.NotImplementedException();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        //throw new System.NotImplementedException();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float dt = SystemAPI.Time.DeltaTime;
        //foreach (TransformAspect ta in SystemAPI.Query<TransformAspect>())
        //{
        //    Debug.Log("Transform");
        //}
        //foreach (RefRO<ObstacleUpBeginComponent> ta in SystemAPI.Query<RefRO<ObstacleUpBeginComponent>>())
        //{
        //    Debug.Log("Transform");
        //}
        //foreach ((TransformAspect ta, RefRO<ObstacleUpBeginComponent> spd) in SystemAPI.Query<TransformAspect, RefRO<ObstacleUpBeginComponent>>())
        //{
        //    Debug.Log("aaaaa");
        //    ta.WorldPosition += new Unity.Mathematics.float3(dt * -spd.ValueRO.velocity, 0, 0);
        //}

        JobHandle jobHandle = new ObstacleJobMove
        {
            deltaTime = dt
        }.ScheduleParallel(state.Dependency);
        jobHandle.Complete();
        JobHandle jobHandle2 = new ObstacleJobCheck
        {
        }.ScheduleParallel(state.Dependency);
        
        jobHandle2.Complete();

    }

}


[BurstCompile]
public partial struct ObstacleJobMove : IJobEntity
{
    
    public float deltaTime;

    [BurstCompile]
    public void Execute(ObstacleUpBeginAspect aspect)
    {
        aspect.Move(deltaTime);
    }

}

[BurstCompile]
public partial struct ObstacleJobCheck : IJobEntity
{


    [BurstCompile]
    public void Execute(ObstacleUpBeginAspect aspect)
    {
        aspect.changeVelocity();
    }
}

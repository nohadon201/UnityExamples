using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;


[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        //EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        //foreach (RefRW<ParticleComponent> particleComponent in SystemAPI.Query<RefRW<ParticleComponent>>())
        //{
        //    particleComponent.ValueRW.time -= SystemAPI.Time.DeltaTime;

        //    if (particleComponent.ValueRW.time <= 0)
        //    {

        //        particleComponent.ValueRW.time = particleComponent.ValueRO.delay;
        //        Entity spawnedEntity;
        //        spawnedEntity = entityCommandBuffer.Instantiate(particleComponent.ValueRO.particleEntity);
        //        entityCommandBuffer.SetComponent(spawnedEntity, new ObstacleUpBeginComponent
        //        {
        //            velocity = randomComponent.ValueRW.random.NextFloat(1f, 10f)
        //        });
        //        entityCommandBuffer.SetComponent(spawnedEntity, WorldTransform.FromPosition(new Unity.Mathematics.float3(randomComponent.ValueRW.random.NextFloat(-8f, 8f), 0, randomComponent.ValueRW.random.NextFloat(-8f, 8f))));
        //    }
        //}


    }


}

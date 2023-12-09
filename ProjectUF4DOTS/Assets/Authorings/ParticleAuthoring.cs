using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ParticleAuthoring : MonoBehaviour
{
    public GameObject particleGameObject;
    public float delay;
}
public class ParticleBaker : Baker<ParticleAuthoring>
{
    public override void Bake(ParticleAuthoring authoring)
    {
        AddComponent(new ParticleComponent
        {
            particleEntity = GetEntity(authoring.particleGameObject),
            delay = authoring.delay,
            time = authoring.delay
        }) ;
    }
}

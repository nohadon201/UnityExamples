using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct ParticleComponent : IComponentData
{
    public Entity particleEntity;
    public float delay;
    public float time;
}

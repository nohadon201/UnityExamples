using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RandomAuthoring : MonoBehaviour
{
    [Header("Random")]
    public bool useSeed = false;
    public ushort seed = 1;
    class RandomBaker : Baker<RandomAuthoring>
    {
        public override void Bake(RandomAuthoring authoring)
        {
            AddComponent(new RandomComponent
            {
                random = authoring.useSeed ? new Unity.Mathematics.Random(authoring.seed) : new Unity.Mathematics.Random((ushort)Random.Range(1, 69000))
            });
        }
    }
}

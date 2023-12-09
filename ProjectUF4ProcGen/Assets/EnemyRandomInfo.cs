using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Procedural Generation/EnemyRandomInfo", fileName = "EnemyRandomInfo")]
public class EnemyRandomInfo : ScriptableObject
{
    public List<RandomEnemyObject> list = new List<RandomEnemyObject>();    
}
[Serializable]
public struct RandomEnemyObject
{
    public List<int> Seed;
    public List<int> Frequency;
    public List<int> OffsetX;
    public List<int> OffsetY;
}
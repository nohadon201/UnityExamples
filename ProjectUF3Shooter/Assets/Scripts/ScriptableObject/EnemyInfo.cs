using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]
public class EnemyInfo : ScriptableObject
{
    [SerializeField]
    [DefaultValue(5)]
    [Description("The number of lives of the enemy.")]
    public int lives = 5;
}

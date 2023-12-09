using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    [SerializeField]
    [DefaultValue(5)]
    [Description("The number of charges that can make.")]
    public int Ammunition;
    [SerializeField]
    [DefaultValue(3)]
    [Description("The number of bullets that have the player.")]
    public int Bullets;
}

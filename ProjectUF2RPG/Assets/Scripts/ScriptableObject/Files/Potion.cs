using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Potion : Items
{
    public int Healthing;
    public Effect effect;
}
public enum Effect
{
    Normal, burned, blessed, cursed, frozen, poisoned, Death
}

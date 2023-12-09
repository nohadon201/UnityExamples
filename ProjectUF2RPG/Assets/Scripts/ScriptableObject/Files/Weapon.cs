using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : Items, Equipable
{
    public int Damage;
    public Attribute attribute;
    public int req;
    public TypeDamage Type;
    public void equip()
    {

    }
}

public enum Attribute
{
    STR, DEX, INT
}
public enum TypeDamage
{
    Steel, Fire, Ice, Shadow, Light
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite sprite;
}
public interface Equipable
{
    public abstract void equip();
}
public interface Consumible
{
    public abstract void Consume();
}




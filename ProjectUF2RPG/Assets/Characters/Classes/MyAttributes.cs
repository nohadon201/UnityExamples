using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyAttributes
{
    [SerializeField, Range(0, 100)] public float Dexterity;
    [SerializeField, Range(0, 100)] public float Intelligence;
    [SerializeField, Range(0, 100)] public float Strength;
    [SerializeField, Range(0, 100)] public float Vitality;
    [SerializeField, Range(0, 100)] public float Velocity;

    public int getDexterity { get => Mathf.FloorToInt(Dexterity); }
    public int getIntelligence { get => Mathf.FloorToInt(Intelligence); }
    public int getStrength { get => Mathf.FloorToInt(Strength); }
    public int getVitality { get => Mathf.FloorToInt(Vitality); }
    public int getVelocity { get => Mathf.FloorToInt(Velocity); }
}
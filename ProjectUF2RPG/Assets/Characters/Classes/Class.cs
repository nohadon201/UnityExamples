using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Class : ScriptableObject
{
    private Classes m_Type;

    private float m_Dexterity;
    private float m_Intelligence;
    private float m_Strength;
    private float m_Vitality;
    private float m_Velocity;

    public float[] attributesDefinition() {
        return new float[] { m_Dexterity, m_Intelligence, m_Strength, m_Vitality, m_Velocity };
    }

    public Classes Type { get => m_Type; private set => m_Type = value; }

    protected List<Skill> m_Skills;
}
[Serializable]
public class DefineClass {

    [SerializeField]
    private string m_NameOfClass;
    [SerializeField, Range(10, 100)]
    private int m_Dexterity;
    [SerializeField, Range(10, 100)]
    private int m_Intelligence;
    [SerializeField, Range(10, 100)]
    private int m_Strength;
    [SerializeField, Range(10, 100)]
    private int m_Vitality;
    [SerializeField, Range(10, 100)]
    private int m_Velocity;

}
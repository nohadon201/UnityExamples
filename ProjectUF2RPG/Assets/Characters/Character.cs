using System;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "New Character", order = 1)]
public class Character : ScriptableObject , Equippable {

    //Personal-Data
    [Space(5)]
    [SerializeField, Header("Personal Data")] private string m_CharacterName;
    [SerializeField] Classes m_CharacterClass;
    Class m_Class;
    public Class Class { get => m_Class; private set => m_Class = value; }

    //Attributes
    int m_Experience = 0;
    int m_MaxExperience = 100;
    int m_Heatlh;
    int m_MaxHeatlh;
    public int Experience { get => m_Experience; private set => m_Experience = value; }
    public int MaxExperience { get => m_MaxExperience; private set => m_MaxExperience = value; }
    public int Heatlh { get => m_Heatlh; private set => m_Heatlh = value; }
    public int MaxHeatlh { get => m_MaxHeatlh; private set => m_MaxHeatlh = value; }

    //Attributes-Custom
    [Space(10)]
    [SerializeField, Range(1, 60), Header("Attributes"), Space(2)] private int m_Level;
    public int Level { get => m_Level; private set => m_Level = value; }

    [SerializeField] MyAttributes m_Attributes;

    //Equipment
    Dictionary<SlotsEquipment, Equipment> m_MyEquipment = new Dictionary<SlotsEquipment, Equipment>();
    [SerializeField] List<SlotsEquipment> ExcludedSlots;

    private void Awake()
    {
        foreach (SlotsEquipment pieceType in Enum.GetValues(typeof(SlotsEquipment))) {
            if (ExcludedSlots.Contains(pieceType))
                continue;
            m_MyEquipment.Add(pieceType, null);
        }
    }

    public void Damage() {
        
    }

    // ToDo
    public Equipment[] TryToEquip(Equipment item)
    {
        Equipment[] myEquipment = null;
        foreach (KeyValuePair<SlotsEquipment, Equipment> Equipment in m_MyEquipment)
        {
            if (Equipment.Key == item.SlotWhichOccup) {
                m_MyEquipment.Add(Equipment.Key, item);
                myEquipment[0] = Equipment.Value;
                return myEquipment;
            }
        }
        return myEquipment;
    }

    public void lvlUp() {
        if (m_Class == null)
            return;
        m_Level++;
        float[] attrDef = m_Class.attributesDefinition();
        m_Attributes.Dexterity = attrDef[0] * m_Level;
        m_Attributes.Intelligence = attrDef[1] * m_Level;
        m_Attributes.Strength = attrDef[2] * m_Level;
        m_Attributes.Vitality = attrDef[3] * m_Level;
        m_Attributes.Velocity = attrDef[4] * m_Level;

        // ToDo
        m_MaxHeatlh = Mathf.FloorToInt(m_Attributes.Vitality * m_Level * 10);
        m_Heatlh = m_MaxHeatlh;
        m_MaxExperience = m_Level * 100;
    }

    public void addExperience(int xp) {
        if (m_Experience + xp >= m_MaxExperience) {
            this.lvlUp();
            m_Experience += m_Experience + xp - m_MaxExperience;
            return;
        }
        m_Experience += xp;
    }
}

public abstract class Skill
{
    
}
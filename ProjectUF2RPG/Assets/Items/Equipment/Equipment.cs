using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Item/New Equipment", order = 1)]

public class Equipment : ScriptableObject
{
    int Armadura = 10;
    int DefensaElemental = 30;
    [SerializeField] private string m_EquipmentName;
    [SerializeField] private string m_ConceptType;
    [SerializeField, TextArea] private string m_Description;
    [SerializeField] private List<Classes> m_CompatibleWith;
    [SerializeField] private List<SlotsEquipment> m_OccupySlots;
    [SerializeField] private SlotsEquipment m_SlotWhichOccup;
    [SerializeField] private MyAttributes m_Attributes;
    public MyAttributes Attributes { get => m_Attributes; }
    public SlotsEquipment SlotWhichOccup { get => m_SlotWhichOccup; private set => m_SlotWhichOccup = value; }
}

public enum SlotsEquipment {
    Shoulders, 
    Chest, 
    Belt, 
    Helmet, 
    Neck,
    Gloves, 
    Boots, 
    Pants, 
    leftHand, 
    rightHand 
}

public enum _Attribute {
    Dexterity,
    Intelligence,
    Strength,
    Vitality,
    Velocity
}

public enum TypeEquipment {
    Passive,
    Offensive,
    Defensive
}

public interface Equippable
{
    public Equipment[] TryToEquip(Equipment item);
}


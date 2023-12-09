using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [Space(3)]
    [SerializeField] private List<Items> items = new List<Items>(); 
    [SerializeField] private List<Character> Team = new List<Character>();
    [SerializeField] private Transform transform_player;
    public int Coins;

    public void addObjectToInventary(Items i)
    {
        this.items.Add(i);
    }
    public Items AccessToObject(int ind)
    {
        return items[ind];
    }
    public List<Consumible> returnConsumibles()
    {
        List<Consumible> list = new List<Consumible>();
        foreach (var item in this.items)
        {
            if(item is Consumible)
            {
                list.Add((Consumible)item);
            }
        }
        return list;
    }
    public List<Equipable> returnEquipable()
    {
        List<Equipable> list = new List<Equipable>();
        foreach (var item in this.items)
        {
            if (item is Equipable)
            {
                list.Add((Equipable)item);
            }
        }
        return list;
    }

    public List<Character> team { get => Team; private set => Team = value; }
    public Transform transform { get => transform_player; private set => transform_player = value; }
}

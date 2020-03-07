using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour 
{
    //make id and name readonly?
    int ID;
    public int price;

    public string name;

    public string tag;

    List<Resistence> resistences = new List<Resistence>();

    public List<Mod> mods = new List<Mod>();

    public int p_armor;
    public int m_armor;

    private void Start()
    {
        ID = ID_Manager.GiveSourceID();
    }

    /*Armor()
    {
        ID = ID_Manager.GiveSourceID();
        price = 0;
        name = "Default";
        p_armor = 0;
        m_armor = 0;
    }
    Armor(string name, int price, int p_armor, int m_armor, string tag, List<Resistence> resistences)
    {
        this.name = name;
        price = 0;
        this.p_armor = p_armor;
        this.m_armor = m_armor;
        this.tag = tag;
        AddResistences(resistences);

    }*/
    public void AddResistences(List<Resistence> resistences)
    {
        foreach(Resistence resistence in resistences)
        {
            this.resistences.Add(resistence);
        }
    }
    public int GetPArmor()
    {
        return p_armor;
    }
    public int GetMArmor()
    {
        return m_armor;
    }
    public int GetID()
    {
        return ID;
    }

}

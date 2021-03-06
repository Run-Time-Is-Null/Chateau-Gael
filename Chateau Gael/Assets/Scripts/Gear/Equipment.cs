﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    //This is the class for keeping track of the entity's equipment
    //It has references to two weapons and armor for each part
    //This will also handel damage resistences in the future... maybe
    //I have a separate class for resistences but that's more for keeping track of them and organization
    //I'll have to see

    //Weapons
    public Weapon wpn1;
    public Weapon wpn2;

    //Armor
    /*public Armor head;
    public Armor body;
    public Armor legs;
    public Armor hands;*/

    public List<Armor> armors = new List<Armor>(4);

    //Max and current armor values
    public int max_p_armor;
    public int max_m_armor;
    public int current_p_armor;
    public int current_m_armor;

    //Equips the armor based on it's tag
    //I will eventually figure out a tag system to use
    //It'll make organization of everything so much easier
    //Like an enemy having a tag for what type it is, it's battle position. Weapons with like reach, or cleave. ect...
    void EquipArmor(Armor armor)
    {
        switch (armor.tag)
        {
            case "head":
                armors[0] = armor;
                break;
            case "body":
                armors[1] = armor;
                break;
            case "legs":
                armors[2] = armor;
                break;
            case "hands":
                armors[3] = armor;
                break;
            default:
                break;
        }
        CalculateArmor();
    }
    //Equips weapon
    public void EquipWeapon(Weapon weapon)
    {
        switch (weapon.tag)
        {
            case "right":
                wpn1 = weapon;
                break;
            case "left":
                wpn2 = weapon;
                break;

        }
    }
    //Adds up all the armor values of equipped armor and sets the max and current armor values to that
    public void CalculateArmor()
    {
        max_p_armor = 0;
        max_m_armor = 0;

        if(armors != null)
        {
            foreach (Armor armor in armors)
            {
                max_p_armor += armor.p_armor;
                max_m_armor += armor.m_armor;
            }
        }


        current_p_armor = max_p_armor;
        current_m_armor = max_m_armor;
    }

    //Simple get statements
    public int GetMaxPArmor()
    {
        return max_p_armor;
    }
    public int GetMaxMArmor()
    {
        return max_m_armor;
    }
    public int Damage(int damage)
    {
        if(current_p_armor >= 1)
        {
            if (damage <= current_p_armor)
            {
                current_p_armor -= damage;
                Debug.Log("But their armor protected them completely!");
                Debug.Log("Current armor: " + current_p_armor);
                return 0;
            }
            else
            {
                damage -= current_p_armor;
                current_p_armor = 0;
                Debug.Log("Their armor mitigated the damage but now it's destroyed!");
                Debug.Log("Current armor: " + current_p_armor);
                return damage;
            }
        }
        Debug.Log("And they have no more armor to protect against it!");
        return damage;



    }


}

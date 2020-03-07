using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    //Oh, boy. This is the class for the entity's stats
    //It's actually a bit more complicated than I thought at first, or as it may appear
    //Basically, the stat is given a name and a base value
        //Then, whenever needed it will check and add its modifiers together
        //Adds adition moddifiers to the stat, and then percentage ones
        //Then you have the true_value which will be used in the actual combat

    //The stat's name
    readonly string stat_name;

    //Base and true value
    private int base_value;
    int true_value;
    //A list of all the modifiers - explained more in the mods class
    List<Mod> mods = new List<Mod>();

    //Just used to add to the base value to get the true value
    //Will probably just move them sometime because they don't need global scope
    int addition_mod;
    float multiplication_mod;

    //Constructors - made two just in case
    public Stat(string stat_name, int value)
    {
        this.stat_name = stat_name;
        this.base_value = value;
    }
    public Stat(string stat_name)
    {
        this.stat_name = stat_name;
        this.base_value = 1;
    }

    //Adds a new modifier to the list
    //Checks if it's already there because of the ID
    //Remove mod is the same just the reverse :P
    public bool AddMod(Mod new_mod)
    {
        foreach(Mod mod in mods)
        {
            if(mod.id == new_mod.id)
            {
                return false;
            }
        }
        mods.Add(new_mod);
        return true;
    }
    public bool RemoveMod(int id)
    {
        foreach(Mod mod in mods)
        {
            if(mod.id == id)
            {
                mods.Remove(mod);
                return true;
            }
        }
        return false;
    }

    //Sets the addition and multiplication total modifiers
    //Will probably just have it be in the SetTrueValue method
    public bool SetMods()
    {
        addition_mod = 0;
        multiplication_mod = 0;

        foreach(Mod mod in mods)
        {
            if(mod.mod.GetType() == typeof(int))
            {
                addition_mod += mod.mod;
            }else if(mod.mod.GetType() == typeof(float))
            {
                multiplication_mod += mod.mod;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    //Sets the true value by using the modifiers
    public void SetTrueValue()
    {
        true_value = base_value;
        true_value += addition_mod;
        float temp_value = (float)true_value;
        temp_value *= multiplication_mod;
        true_value += (int)temp_value;
    }

    //Gets the base value if needed. Ya never know.
    public int GetBaseValue()
    {
        return base_value;
    }

    //Returns the true value. This is the one that will actually be used
    public int GetStat()
    {
        return true_value;
    }
}

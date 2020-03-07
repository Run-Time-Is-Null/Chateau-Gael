using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    #region Head Comments
    //This is the parent class for all enemies and party members
    //It is mainly (and hopefully in the future, only) stats
    //So it has their 3 main stats, AP, and health
    //Their equipment is kept track in a separate object called Equipment
    //It's tied to it's prefab already set up, but for safety I'll have it check it has one just to be safe
    #endregion

    //These are the three stats used by all entities
    public Stat str;
    public Stat dex;
    public Stat wis;

    //These are simply ints that are given their value in the inspector
    //This way you can easily change and set the entity's stats
    public int init_str;
    public int init_dex;
    public int init_wis;


    //The entity's AP
    public int AP;

    //Health obviously
    public int max_health;
    public int current_health;

    //This is declaring an Equipment object
    //I don't have it creating one here yet
    //At the moment its given a reference to it in the inspector
    //The prefab this is set to also has an equipment object already set to it
    public Equipment equipment;

    private void Start()
    {

        //Combat_DM.On_Turn_End += ShowStat;

        //Since I can't (or can but it's a headache) instantiate the stats in the inspector I have you put in their values and then set them in here
        //Not a bad work around honestly

        if (init_str >= 1)
        {
            str = new Stat("str", init_str);
        }
        else
        {
            str = new Stat("str");
        }
        if(init_dex >= 1)
        {
            dex = new Stat("dex", init_dex);
        }
        else
        {
            dex = new Stat("dex");
        }
        if(init_wis >= 1)
        {
            wis = new Stat("wis", init_wis);
        }
        else
        {
            wis = new Stat("wis");
        }
        str.SetTrueValue();
        max_health = str.GetStat();
        current_health = max_health;
        dex.SetTrueValue();
        wis.SetTrueValue();
        equipment.CalculateArmor();



    }

    void ShowStat()
    {
        Debug.Log(str.GetStat());
    }

    public void Damage(int damage)
    {
        Debug.Log(name + " is dealt " + damage + " damage!");
        current_health -= equipment.Damage(damage);
        Debug.Log("Current health: " + current_health);
    }


}

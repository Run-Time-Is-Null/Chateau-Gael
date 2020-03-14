using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Mod 
{
    //Not too complex but this is the mod class
    //The main reason it exists is to just help with organization
    //It gets the modifier (either integer or float) and an ID
    //It'll get the ID from whatever source it came from thanks to ID_Manager
    //I'm using dynamic so that I can have one variable name for mod
    //The two constructors are so it can only be given a float or integer
    //Just realized that the way I had it before meant you could pass a string or something else

    public string stat;
    public int mod;
    public int id;


    public Mod(string stat, int mod)
    {
        this.stat = stat;
        this.mod = mod;
    }
}

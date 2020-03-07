using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistence 
{
    string name;
    float resistence;
    int ID;
    Resistence()
    {
        name = "Default";
        resistence = 1f;
    }
    Resistence(string name)
    {
        this.name = name;
        resistence = 1f;
    }
    Resistence(float resistence)
    {
        name = "Default";
        this.resistence = resistence;
    }
    Resistence(string name, float resistence)
    {
        this.name = name;
        this.resistence = resistence;
    }
    public string GetName()
    {
        return name;
    }
    public float GetResistence()
    {
        return resistence;
    }
}

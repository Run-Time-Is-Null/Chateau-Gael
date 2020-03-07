using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int price;
    public int damage;
    public string tag;
    int ID;

    private void Start()
    {
        ID = ID_Manager.GiveSourceID();
    }
    public int GiveID()
    {
        return ID;
    }
}

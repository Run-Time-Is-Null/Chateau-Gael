using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ID_Manager
{

    //Class for the ID_Manager
    //Very simple right now but will probably expand later on
    //Right now it simply gives a unique ID to weapons and armor to identify their potential buffs and debuffs
    //Since the class is static, no matter where it's used the id number will always be correct
    //The reason I have this instead of manually giving IDs, is:
        //It'd be annoying and a pain in the ass to manually do it
        //It would also lead to debugging hell because of having to check if the ID is correct
        //Would also have to make sure any new gear had a unique ID which would be annoying
        //So I think this system works best

    static int source_id = 0;

    public static int GiveSourceID()
    {
        source_id += 1;
        return source_id;
    }
}

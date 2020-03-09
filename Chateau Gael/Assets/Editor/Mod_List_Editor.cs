using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Mod_List_Editor 
{
    public static List<Mod> Show(List<Mod> mods)
    {
        foreach(Mod mod in mods)
        {

            //EditorGUILayout.TextField(mod.stat);
            //EditorGUILayout.IntField(mod.mod);

        }
        return mods;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Armor)), CanEditMultipleObjects]
public class ModScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Armor armor = (Armor)target;



        armor.tag = EditorGUILayout.TextField("Tag", armor.tag);
        armor.price = EditorGUILayout.IntField("Price", armor.price);
        armor.p_armor = EditorGUILayout.IntField("Physical Armor", armor.p_armor);
        armor.m_armor = EditorGUILayout.IntField("Magical Armor", armor.m_armor);
        EditorGUILayout.TextField("test", "man");

        EditorGUILayout.BeginHorizontal();
        string a = EditorGUILayout.TextField("Stat", "stat");
        int b = EditorGUILayout.IntField("Mod", 0);
        EditorGUILayout.EndHorizontal();

        List<string> stats = new List<string>();
        List<int> mods = new List<int>();

        
        

        

        serializedObject.Update();
        Editor_List.Show(serializedObject.FindProperty("mods"));
        //Mod_List_Editor.Show(mods);

        serializedObject.ApplyModifiedProperties();



        //EditorGUILayout.LabelField("ID", armor.GetID().ToString());
    }
}

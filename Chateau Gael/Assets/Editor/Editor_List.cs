using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_List
{

    public enum Stat { str,dex,wis}

    public static void Show(SerializedProperty list)
    {

            EditorGUILayout.PropertyField(list);
            EditorGUI.indentLevel += 1;
            if (list.isExpanded)
            {
                for (int i = 0; i < list.arraySize; i++)
                {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
                InnerShow(list.GetArrayElementAtIndex(i));
                    
                }
            }
            EditorGUI.indentLevel -= 1;
    }
    static void InnerShow(SerializedProperty list)
    {
        var childEnum = list.GetEnumerator();
        if (list.isExpanded)
        {
            EditorGUILayout.BeginHorizontal();
            while (childEnum.MoveNext())
            {

                var current = childEnum.Current as SerializedProperty;
                if (current.name == "mod")
                {
                    EditorGUILayout.PropertyField(current);
                }
                else if (current.name == "stat")
                {
                    EditorGUILayout.PropertyField(current);
                }
            }
            EditorGUILayout.EndHorizontal();
            
        }

        /*EditorGUI.indentLevel += 1;
        mod.mod = EditorGUILayout.IntField("Mod",mod.mod);
        //list.Next(true);
        mod.stat = EditorGUILayout.TextField("Stat", mod.stat);
        EditorGUI.indentLevel -= 1;
        */
    }
}

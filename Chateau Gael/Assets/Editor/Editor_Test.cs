using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(For_Editor_Test))]
public class Editor_Test : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("int_array"));
        serializedObject.ApplyModifiedProperties();
    }
}

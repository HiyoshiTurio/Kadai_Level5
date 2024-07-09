using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyBase))]
public class MyPractice : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _position;
    private void OnEnable()
    {
        _name = serializedObject.FindProperty("_name");
        _position = serializedObject.FindProperty("_position");
    }

    public void OnSceneGUI()
    {
        MyBase myBase= target as MyBase;
        
        serializedObject.Update();

        Vector3 offsetPos = myBase.TmpOffset;
        
        EditorGUI.BeginChangeCheck();
        var newOffsetPos = Handles.PositionHandle(offsetPos, myBase.transform.rotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Change");
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}

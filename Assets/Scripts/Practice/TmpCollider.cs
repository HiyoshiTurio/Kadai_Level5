using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class TmpCollider : MonoBehaviour
{
    private static Vector3 _thisPos = new Vector3(0,0,0);
    private static Vector3 _addXPos = new Vector3(1,0,0);
    private static Vector3 _addYPos = new Vector3(0,1,0);
    private static Vector3 _addXYPos = new Vector3(1,1,0);
    [SerializeField] private static float _x = 3f;
    [SerializeField] private static float _y = 3f;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void MyDebug()
    {
        // Debug.DrawLine(_thisPos, _addXPos, Color.green);
        // Debug.DrawLine(_thisPos, _addYPos, Color.green);
        // Debug.DrawLine(_addXPos, _addXYPos, Color.green);
        // Debug.DrawLine(_addYPos, _addXYPos, Color.green);
        
    }

    private void OnEnable()
    {
        OnDrawGizmos();
    }

    [MenuItem("LineDebug/namae")]
    public static void OnDrawGizmos()
    {
        Line();
        Vector3[] _vertex = new Vector3[4];
        _vertex[0] = _thisPos;
        _vertex[1] = _addXPos;
        _vertex[2] = _addXYPos;
        _vertex[3] = _addYPos;
        for (int i = 0; i < _vertex.Length - 1; i++)
        {
            Debug.DrawLine(_vertex[i], _vertex[i + 1], Color.green);
        }
    }
    static void Line()
    {
        _thisPos = new Vector3(0, 0, 0);
        _addXPos = new Vector3(_thisPos.x + _x, _thisPos.y, _thisPos.z);
        _addYPos = new Vector3(_thisPos.x, _thisPos.y + _y, _thisPos.z);
        _addXYPos = new Vector3(_thisPos.x + _x, _thisPos.y + _y, _thisPos.z);
    }
}

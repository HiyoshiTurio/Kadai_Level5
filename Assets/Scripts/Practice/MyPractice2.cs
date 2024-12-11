using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPractice2 : MonoBehaviour
{
    [SerializeField] private float _x = 2f;
    [SerializeField] private float _y = 2f;
    private Vector3 _thisPos;
    private void OnDrawGizmos()
    {
        //Gizmos.matrix = transform.localToWorldMatrix;
        _thisPos = this.transform.position;
        Vector3[] _vector3s = new Vector3[4];
        _vector3s[0] = _thisPos;
        _vector3s[1] = new Vector3(_thisPos.x + _x, _thisPos.y, _thisPos.z);
        _vector3s[2] = new Vector3(_thisPos.x + _x, _thisPos.y + _y, _thisPos.z);
        _vector3s[3] = new Vector3(_thisPos.x, _thisPos.y + _y, _thisPos.z);
        
        
        Gizmos.color = Color.green;

        for (int i = 0; i < _vector3s.Length; i++)
        {
            Gizmos.DrawLine(_vector3s[i], i < _vector3s.Length - 1 ?  _vector3s[i + 1] : _vector3s[0]);
        }
    }
}

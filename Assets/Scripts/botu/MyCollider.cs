using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollider : MonoBehaviour
{
    [SerializeField] private Vector3 _range;
    private Vector3 _pivot => this.transform.position;
    public Vector3 _min => new Vector3(_pivot.x - _range.x / 2, _pivot.y - _range.y / 2, _pivot.z);
    public Vector3 Pivot => _pivot;
    public float _size_cx => _range.x;
    public float _size_cy => _range.y;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3[] _vector3s = new[]
        {
            new Vector3(_pivot.x - _range.x/2, _pivot.y + _range.y/2, _pivot.z),
            new Vector3(_pivot.x + _range.x/2, _pivot.y + _range.y/2, _pivot.z),
            new Vector3(_pivot.x + _range.x/2, _pivot.y - _range.y/2, _pivot.z),
            new Vector3(_pivot.x - _range.x/2, _pivot.y - _range.y/2, _pivot.z)
            
        };
        for (int i = 0; i < _vector3s.Length; i++)
        {
            Gizmos.DrawLine(_vector3s[i],_vector3s[i + 1 >= _vector3s.Length ? 0 : i + 1]);
        }
    }

}

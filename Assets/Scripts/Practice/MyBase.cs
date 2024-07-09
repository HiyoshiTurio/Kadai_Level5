using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyBase : MonoBehaviour
{
    private Vector3 _thisPos;
    public Vector3 TmpOffset => _tmpOffset;
    public float X => _x;
    public float Y => _y;

    [SerializeField] private Vector3 _tmpOffset;
    [SerializeField] private float _x = 3f;
    [SerializeField] private float _y = 3f;
    
    // void OnDraw()
    // {
    //     _thisPos = transform.position;
    //     Line();
    //     Vector3[] _vertex = new Vector3[4];
    //     _vertex[0] = _thisPos;
    //     _vertex[1] = new Vector3(_thisPos.x + _x, _thisPos.y, _thisPos.z);
    //     _vertex[2] = new Vector3(_thisPos.x + _x, _thisPos.y + _y, _thisPos.z);
    //     _vertex[3] = new Vector3(_thisPos.x, _thisPos.y + _y, _thisPos.z);
    //     for (int i = 0; i < _vertex.Length - 1; i++)
    //     {
    //         Vector3 tmp = i + 1 > _vertex.Length ? _vertex[i + 1] : _vertex[0];
    //         Debug.DrawLine(_vertex[i], _vertex[i + 1], Color.green);
    //     }
    // }
    void Line()
    {
        _thisPos = new Vector3(0, 0, 0);
        // _addXPos = new Vector3(_thisPos.x + _x, _thisPos.y, _thisPos.z);
        // _addYPos = new Vector3(_thisPos.x, _thisPos.y + _y, _thisPos.z);
        // _addXYPos = new Vector3(_thisPos.x + _x, _thisPos.y + _y, _thisPos.z);
    }
}

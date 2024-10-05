using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MyRigidBody : MonoBehaviour
{
    [SerializeField] float gravity = 1.0f;
    private float _vx = 0f; // x velocity
    private float _vy = 0f; // y velocity
    private Vector3 _v = new Vector3(0f, 0f, 0f);
    private Vector3 _lastPos;
    public Vector3 V
    {
        get { return _v; }
        set { _v = value; }
    }

    void Start()
    {
        UpdatePos();
    }
    void Update() { }
    void FixedUpdate()
    {
        Check();
        UpdatePos();
    }
    void UpdatePos()
    {
         _v.y -= gravity;
        this.transform.position += _v;
        //_v = Vector3.zero;
        //Debug.Log($"Vy:{_v.y}");
    }

    void Check()
    {
        //if (!(-0.01f < (this.transform.position - _lastPos).y - _v.y && (this.transform.position - _lastPos).y - _v.y < 0.01f))
        Debug.Log($"Vy:{_v.y},{(this.transform.position - _lastPos).y}");
        if(!((this.transform.position - _lastPos).y - _v.y >= 0f))
        {
            _v.y = 0f;
            Debug.Log("Hit");
        }
        _lastPos = this.transform.position;
    }
}

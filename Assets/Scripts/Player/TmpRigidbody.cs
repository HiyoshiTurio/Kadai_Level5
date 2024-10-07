using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpRigidbody : MonoBehaviour
{
    [SerializeField] private float _gravity = 0.05f;
    private float _xSpeed = 0;
    private float _ySpeed = 0;
    private Vector3 _v = Vector3.zero;

    public float XSpeed
    {
        get => _xSpeed;
        set => _xSpeed = value;
    }
    public float YSpeed
    {
        get => _ySpeed;
        set => _ySpeed = value;
    }

    public Vector3 V
    {
        get => _v;
        set => _v = value;
    }

    private void FixedUpdate()
    {
        TmpRigidBody();
    }

    void TmpRigidBody()
    {
        _ySpeed -= _gravity;
        _v.x = _xSpeed;
        _v.y = _ySpeed;
        transform.position += _v;
    }
}
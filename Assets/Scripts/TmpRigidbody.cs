using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class TmpRigidbody : MonoBehaviour
{
    [SerializeField] private float _gravity = 0.05f;
    private float _xSpeed = 0;
    private float _ySpeed = 0;
    private Vector3 _pos;

    public float XSpeed
    {
        get => _xSpeed;
        set
        {
            _xSpeed = value;
        }
    }
    public float YSpeed
    {
        get => _ySpeed;
        set
        {
            _ySpeed = value;
        }
    }

    private void FixedUpdate()
    {
        TmpRigidBody();
    }

    void TmpRigidBody()
    {
        _ySpeed -= _gravity;
        
        Vector3 tmp = this.transform.position;
        tmp.x += _xSpeed;
        tmp.y += _ySpeed;
        this.transform.position = tmp;
    }

    public void OnGround()
    {
        _ySpeed = 0;
    }
}
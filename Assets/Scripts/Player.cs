using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mazzle;
    [SerializeField] private float _jumpPower = 22f;
    [SerializeField] private float _minPosY = -3f;
    [SerializeField] private float _gravity = 2f;
    [SerializeField] private int _maxJumpCount = 1;
    private float _fixedParam = 60f;
    private float _ySpeed = 0;
    private int _jumpCounter = 0;
    bool _isGround = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShotBullet();
        }

        if (Input.GetButtonDown("Jump") && _jumpCounter > -1)
        {
            Jump();
            _jumpCounter--;
        }

        if (this.transform.position.y < _minPosY)
        {
            _isGround = true;
            this.transform.position = new Vector3(this.transform.position.x, _minPosY + 0.01f, 0);
            _jumpCounter = _maxJumpCount;
        }
        else
        {
            _isGround = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_isGround)
        {
            TmpRigidBody();
        }
    }

    void ShotBullet()
    {
        GameObject _tmpBullet = Instantiate(_bullet, _mazzle.transform.position, Quaternion.identity);
        _tmpBullet.transform.up = _mazzle.transform.up;
    }

    void Jump()
    {
        _ySpeed = _jumpPower / _fixedParam;
    }

    void TmpRigidBody()
    {
        _ySpeed -= _gravity / _fixedParam;
        Vector2 tmp = this.transform.position;
        tmp.y += _ySpeed;
        this.transform.position = tmp;
    }
}
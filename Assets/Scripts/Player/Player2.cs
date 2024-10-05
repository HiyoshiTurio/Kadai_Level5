using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mazzle;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 0.6f;
    [SerializeField] private float _minPosY = -3f;
    [SerializeField] private int _maxJumpCount = 2;
    TmpRigidbody _tmpRigidbody;
    private int _jumpCounter = 0;

    private void Start()
    {
        _tmpRigidbody = GetComponent<TmpRigidbody>();
        //GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
    }

    private void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            ShotBullet();
        }

        if (this.transform.position.y < _minPosY)
        {
            Vector3 tmp = this.transform.position;
            tmp.y = _minPosY;
            this.transform.position = tmp;
            _tmpRigidbody.OnGround();
            _jumpCounter = _maxJumpCount;
        }

        if (Input.GetButtonDown("Jump") && _jumpCounter > 0)
        {
            Jump();
            _jumpCounter--;
        }
    }

    // void Hit(AABBCollision other)
    // {
    //     
    // }

    void ShotBullet()
    {
        GameObject _tmpBullet = Instantiate(_bullet, _mazzle.transform.position, Quaternion.identity);
        _tmpBullet.transform.up = _mazzle.transform.up;
    }

    void Jump()
    {
        _tmpRigidbody.YSpeed = _jumpPower;
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _tmpRigidbody.XSpeed = h * _speed;
    }
}
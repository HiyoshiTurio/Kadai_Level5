using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject mazzle;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 0.6f;
    [SerializeField] private float minPosY = -3f;
    [SerializeField] private int maxJumpCount = 2;
    TmpRigidbody _tmpRigidbody;
    private int _jumpCounter = 0;

    private void Start()
    {
        _tmpRigidbody = GetComponent<TmpRigidbody>();
        GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
    }

    private void Update()
    {
        Move();
        IsGround();
        if (Input.GetButtonDown("Fire1"))
        {
            ShotBullet();
        }
        if (Input.GetButtonDown("Jump") && _jumpCounter > 0)
        {
            Jump();
            _jumpCounter--;
        }
    }

    void Hit(AABBCollision other)
    {
        
    }

    void ShotBullet()
    {
        GameObject tmpBullet = Instantiate(bullet, mazzle.transform.position, Quaternion.identity);
        tmpBullet.transform.up = mazzle.transform.up;
    }

    void Jump()
    {
        _tmpRigidbody.YSpeed = jumpPower;
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _tmpRigidbody.XSpeed = h * speed;
    }

    void IsGround()
    {
        if (this.transform.position.y < minPosY)
        {
            Vector3 tmp = this.transform.position;
            tmp.y = minPosY;
            this.transform.position = tmp;
            _tmpRigidbody.YSpeed = 0;
            _jumpCounter = maxJumpCount;
        }
    }
}
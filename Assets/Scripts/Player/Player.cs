using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject raser;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 0.6f;
    [SerializeField] private float minPosY = -3f;
    [SerializeField] private int maxJumpCount = 2;
    private float _inputTimer = 0.0f;
    private bool _isButtonDown = false;
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
            _isButtonDown = true;
            _inputTimer = 0;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (_inputTimer >= 6.0f)
            {
                ShotRaser();
            }
            else
            {
                ShotBullet();
            }
            _isButtonDown = false;
        }
        if (Input.GetButtonDown("Jump") && _jumpCounter > 0)
        {
            Jump();
            _jumpCounter--;
        }
    }

    private void FixedUpdate()
    {
        if (_isButtonDown)
        {
            _inputTimer += 0.1f;
        }
    }

    void Hit(AABBCollision other)
    {
        
    }

    void ShotRaser()
    {
        GameObject tmpRaser = Instantiate(raser);
        tmpRaser.GetComponent<Raser>().ShotRaser(muzzle.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void ShotBullet()
    {
        GameObject tmpBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        tmpBullet.transform.up = muzzle.transform.up;
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
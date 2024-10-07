using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPlayerState
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    TmpRigidbody _rigidbody;
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("DestryBullet", _lifeTime);
        GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
        _rigidbody = GetComponent<TmpRigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = _speed * _fixedSpeed * transform.up;
        _rigidbody.XSpeed = direction.x;
        _rigidbody.YSpeed = direction.y;
    }

    void Hit(AABBCollision other)
    {
        if (other.gameObject.tag == "Player")
        {
            HitPlayer(_damage);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            HitEnemy(_damage);
        }
        DestryBullet();
    }

    void DestryBullet()
    {
        Destroy(gameObject);
    }
    public void HitPlayer(int damage)
    {
    }

    private void HitEnemy(int damage)
    {
        
    }
}

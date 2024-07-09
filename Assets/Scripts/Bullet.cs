using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHit
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    private EnemyManager _enemyManager;
    private MyCollider _bulletCollider;
    private MyCollider playerCollider;
    private float _fixedSpeed = 0.01f;
    
    private void Start()
    {
        Invoke("Destroy", _lifeTime);
        _enemyManager = EnemyManager.Instance;
        _bulletCollider = GetComponent<MyCollider>();
        playerCollider = _enemyManager.PlayerMyCollider;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.position += _speed * _fixedSpeed * transform.up;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    void MyColliderOnEnter()
    {
        Vector3 playerPivot = playerCollider.Pivot;
        float player_cx = playerCollider._size_cx;
        float player_cy = playerCollider._size_cy;

        Vector3 bulletPivot = _bulletCollider.Pivot;
        float bullet_cx = _bulletCollider._size_cx;
        float bullet_cy = _bulletCollider._size_cy;

        Vector3 v = _speed * _fixedSpeed * transform.up;
        Vector3 v1 = _enemyManager.PlayerVec;
        Vector3 rv = v - v1;

        if (rv.x != 0)
        {
            float fLineX = (rv.x > 0) ? bulletPivot.x : bulletPivot.x + bullet_cx;
        }
    }
}

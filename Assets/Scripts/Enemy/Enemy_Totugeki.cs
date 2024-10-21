using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Totugeki : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int atk = 1;
    [SerializeField] private float moveSpeed = 0.1f;
    private EnemyManager _enemyManager;
    private TmpRigidbody _rb;
    private bool _isPlayerInAttackRange = false;
    private bool _isHit = false;

    private void Awake()
    {
        _enemyManager = EnemyManager.Instance;
        GetComponent<AABBCollision>().OnAABBEnterEvent += PlayerHit;
        _rb = GetComponent<TmpRigidbody>();
    }

    private void Update()
    {
        if (!_isPlayerInAttackRange)
        {
            if (IsPlayerInAttackRange())
            {
                this.transform.up = _enemyManager.PlayerPos - this.transform.position;
                _isPlayerInAttackRange = true;
            }
        }

        Camera cam = Camera.main;
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        if (!(cam.ViewportToWorldPoint(Vector2.zero).x < x &&
             cam.ViewportToWorldPoint(Vector2.zero).y < y &&
             cam.ViewportToWorldPoint(Vector2.one).x > x &&
             cam.ViewportToWorldPoint(Vector2.one).y > y)
           )
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayerInAttackRange)
        {
            Move();
        }
    }

    void PlayerHit(AABBCollision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isHit)
        {
            collision.gameObject.GetComponent<PlayerState>().Life -= atk;
            _isHit = true;
        }
    }
    void Move()
    {
        _rb.XSpeed = transform.up.x * moveSpeed;
        _rb.YSpeed = transform.up.y * moveSpeed;
    }
    bool IsPlayerInAttackRange()
    {
        Vector3 playerPos = _enemyManager.PlayerPos;
        float x = playerPos.x - this.transform.position.x;
        float y = playerPos.y - this.transform.position.y;
        if (x * x + y * y < attackRange * attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

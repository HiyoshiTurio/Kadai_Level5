using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject mazzle;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float attackRange = 1f;
    private int _hp = 5;
    private bool _playerInAttackRange = false;
    private EnemyManager _enemyManager;
    private float _fixTimer = 0;

    void Start()
    {
        _enemyManager = EnemyManager.Instance;
    }

    private void FixedUpdate()
    {
        if (_playerInAttackRange)
        {
            AttackRoutine();
        }
    }

    void AttackRoutine()
    {
        _fixTimer++;
        if (_fixTimer >= 60 * attackSpeed)
        {
            _fixTimer -= 60;
            ShotBullet();
        }
    }
    void ShotBullet()
    {
        GameObject _tmpBullet = Instantiate(bullet, mazzle.transform.position, Quaternion.identity);
        _tmpBullet.transform.up = mazzle.transform.up;
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
            _fixTimer = 0;
            return false;
        }
    }
}
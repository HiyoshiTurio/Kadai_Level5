using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mazzle;
    [SerializeField] private float _attackSpeed = 1f;
    [SerializeField] private float _attackRange = 1f;
    private bool _playerInAttackRange = false;
    private EnemyManager _enemyManager;
    private float _fixTimer = 0;

    void Start()
    {
        _enemyManager = EnemyManager.Instance;
    }

    void Update()
    {
        
        IsPlayerInAttackRange();
    }

    private void FixedUpdate()
    {
        // if (_playerInAttackRange)
        // {
        //     AttackRoutine();
        // }
        AttackRoutine();
    }

    void AttackRoutine()
    {
        _fixTimer++;
        if (_fixTimer >= 60 * _attackSpeed)
        {
            _fixTimer -= 60;
            ShotBullet();
        }
    }
    void ShotBullet()
    {
        GameObject _tmpBullet = Instantiate(_bullet, _mazzle.transform.position, Quaternion.identity);
        _tmpBullet.transform.up = _mazzle.transform.up;
    }

    void IsPlayerInAttackRange()
    {
        Vector3 playerPos = _enemyManager.PlayerPos;
        float x = playerPos.x - this.transform.position.x;
        float y = playerPos.y - this.transform.position.y;
        if (x * x + y * y < _attackRange * _attackRange)
        {
            _playerInAttackRange = true;
        }
        else
        {
            _playerInAttackRange = false;
            _fixTimer = 0;
        }
    }
}
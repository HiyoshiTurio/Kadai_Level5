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
    private EnemyManager _enemyManager;
    private float _fixTimer = 0;

    void Start()
    {
        _enemyManager = _enemyManager.Instance;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
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
}
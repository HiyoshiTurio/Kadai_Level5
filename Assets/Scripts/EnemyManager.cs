using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    private Vector3 _playerPos;
    private GameObject _player;
    public EnemyManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    public Vector3 PlayerPos
    {
        get => _playerPos;
        private set => _playerPos = value;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        PlayerPos = _player.transform.position;
    }
}

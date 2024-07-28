using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    private Vector3 _playerPos;
    private GameObject _player;
    private MyCollider _playerMyCollider;
    private TmpRigidbody _playerTmpRigidbody;
    private AABBCollision _playerAABBCollision;
    private Rect _playerRect;
    public static EnemyManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    public Vector3 PlayerPos
    {
        get => _playerPos;
        private set => _playerPos = value;
    }

    public Vector3 PlayerVec
    {
        get => new Vector3(_playerTmpRigidbody.XSpeed, _playerTmpRigidbody.YSpeed, 0);
    }

    public MyCollider PlayerMyCollider
    {
        get
        {
            return _playerMyCollider;
        }
        private set
        {
            _playerMyCollider = value;
        }
    }

    public AABBCollision PlayerAABBCollision
    {
        get => _playerAABBCollision;
    }

    public Rect playerRect
    {
        get => _playerAABBCollision.Rect;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerMyCollider = _player.GetComponent<MyCollider>();
        _playerTmpRigidbody = _player.GetComponent<TmpRigidbody>();
        _playerAABBCollision = _player.GetComponent<AABBCollision>();
    }
    void Update()
    {
        PlayerPos = _player.transform.position;
    }
}

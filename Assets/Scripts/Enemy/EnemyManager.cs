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
    private TmpRigidbody _playerTmpRigidbody;
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

    // public Vector3 PlayerVec
    // {
    //     get => new Vector3(_playerTmpRigidbody.XSpeed, _playerTmpRigidbody.YSpeed, 0);
    // }

    private void Awake() { Instance = this; }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerTmpRigidbody = _player.GetComponent<TmpRigidbody>();
    }
    void Update()
    {
        PlayerPos = _player.transform.position;
    }
}

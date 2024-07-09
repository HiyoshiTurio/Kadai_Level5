using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private EnemyManager _enemyManager;
    void Start()
    {
        _camera = Camera.main;
        _enemyManager = EnemyManager.Instance;
    }
    void Update()
    {
        Vector3 tmp = _camera.transform.position;
        tmp.x = _enemyManager.PlayerPos.x;
        _camera.transform.position = tmp;
    }
}

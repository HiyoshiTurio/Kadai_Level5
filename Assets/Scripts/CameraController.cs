using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private EnemyManager _enemyManager;
    GameObject player;
    void Start()
    {
        _camera = Camera.main;
        _enemyManager = EnemyManager.Instance;
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 tmp = _camera.transform.position;
        tmp.x = player.transform.position.x;
        _camera.transform.position = tmp;
    }
}

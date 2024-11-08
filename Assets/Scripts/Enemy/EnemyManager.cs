using UnityEngine;

[DefaultExecutionOrder(-1)]
public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;
    private Vector3 _playerPos;
    private GameObject _player;
    private Camera _cam;
    public static EnemyManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    public Vector3 PlayerPos
    {
        get => _player.transform.position;
    }

    public Camera Cam
    {
        get => _cam;
    }

    private void Awake() { Instance = this; }

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _cam = Camera.main;
    }
}

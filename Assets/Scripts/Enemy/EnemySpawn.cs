using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float spawnTime = 2f;
    private bool _isEnemySpawned = false;
    private float _timer = 0f;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!_isEnemySpawned)
        {
            _timer += 1;
            if (_timer >= spawnTime * 60)
            {
                InstantiateEnemy();
            }
        }
        else
        {
            if (transform.childCount == 0)
            {
                _isEnemySpawned = false;
            }
        }
    }

    void InstantiateEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
        _timer = 0f;
        _isEnemySpawned = true;
    }
}

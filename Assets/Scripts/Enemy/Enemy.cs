using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject mazzle;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float attackRange = 1f;
    private GameObject _enemy;
    private int _hp = 3;
    private EnemyManager _enemyManager;
    private float _fixTimer = 0;

    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                Destroy(_enemy);
            }
        }
    }

    void Start()
    {
        _enemyManager = EnemyManager.Instance;
        _enemy = this.gameObject;
    }

    private void FixedUpdate()
    {
        if (IsPlayerInAttackRange())
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
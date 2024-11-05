using UnityEngine;

public class Enemy_Totugeki : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int atk = 1;
    [SerializeField] private float moveSpeed = 0.1f;
    private EnemyManager _enemyManager;
    private TmpRigidbody _rb;
    private bool _isPlayerInAttackRange = false;
    private bool _isHit = false;
    private Camera cam;

    private void Awake()
    {
        _enemyManager = EnemyManager.Instance;
        GetComponent<AABBCollision>().OnAABBEnterEvent += PlayerHit;
        _rb = GetComponent<TmpRigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (!_isPlayerInAttackRange)
        {
            if (IsPlayerInAttackRange())
            {
                this.transform.up = _enemyManager.PlayerPos - this.transform.position;
                _isPlayerInAttackRange = true;
            }
        }

        
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        if (!(cam.ViewportToWorldPoint(Vector2.zero).x < x &&
             cam.ViewportToWorldPoint(Vector2.zero).y < y &&
             cam.ViewportToWorldPoint(Vector2.one).x > x &&
             cam.ViewportToWorldPoint(Vector2.one).y > y)
           )
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayerInAttackRange)
        {
            Move();
        }
    }

    void PlayerHit(AABBCollision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isHit)
        {
            collision.gameObject.GetComponent<PlayerState>().Life -= atk;
            _isHit = true;
        }
    }
    void Move()
    {
        _rb.AddSpeed(transform.up * moveSpeed);
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
            return false;
        }
    }

}

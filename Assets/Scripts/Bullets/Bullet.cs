using UnityEngine;

public class Bullet : CharacterBase
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    MyRigidbody _rigidbody;
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("DestryBullet", _lifeTime);
        _rigidbody = GetComponent<MyRigidbody>();
    }

    private void FixedUpdate()
    {
        if (!_isHitStop)
        {
            Vector2 direction = _speed * _fixedSpeed * transform.up;
            _rigidbody.AddSpeed(direction);
        }
    }

    protected override void AABBCollisionEnter(AABBCollision collision)
    {
        Hit(collision);
    }

    public void Hit(AABBCollision other)
    {
        if (other.gameObject.tag == "Player")
        {
            HitPlayer(other);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            HitEnemy(other);
        }
        DestryBullet();
    }

    void DestryBullet()
    {
        Destroy(gameObject);
    }
    public void HitPlayer(AABBCollision collision)
    {
        collision.gameObject.GetComponent<PlayerState>().Life -= _damage;
    }

    private void HitEnemy(AABBCollision collision)
    {
        collision.gameObject.GetComponent<Enemy>().Hp -= _damage;
    }
}

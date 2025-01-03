using UnityEngine;

public class Bullet : CharacterBase
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    MyRigidbody _rb;
    public string shooterTagName = "";
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("DestryBullet", _lifeTime);
        _rb = GetComponent<MyRigidbody>();
    }

    private void FixedUpdate()
    {
        if (!IsHitStop)
        {
            Vector2 direction = _speed * _fixedSpeed * transform.up;
            _rb.AddSpeed(direction);
        }
    }

    protected override void AABBCollisionEnter(AABBCollision collision)
    {
        Hit(collision);
    }

    public void Hit(AABBCollision other)
    {
        if (!other.gameObject.CompareTag(shooterTagName) && !other.gameObject.CompareTag("Bullet"))
        {
            HitOther(other);
            DestryBullet();
        }
    }

    void DestryBullet()
    {
        Destroy(gameObject);
    }
    public void HitOther(AABBCollision collision)
    {
        IAddDamage tmp = collision.gameObject.GetComponent<IAddDamage>();
        if (tmp != null)
        {
            tmp.AddDamage(_damage);
        }
    }
}

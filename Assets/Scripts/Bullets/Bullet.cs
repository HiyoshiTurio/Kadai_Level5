using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    TmpRigidbody _rigidbody;
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("DestryBullet", _lifeTime);
        GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
        _rigidbody = GetComponent<TmpRigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = _speed * _fixedSpeed * transform.up;
        _rigidbody.XSpeed = direction.x;
        _rigidbody.YSpeed = direction.y;
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

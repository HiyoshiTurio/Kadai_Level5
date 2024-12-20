using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : CharacterBase, IHitStop
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    MyRigidbody _rigidbody;
    private float _fixedSpeed = 0.01f;
    private bool _isHitStop = false;

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
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerState>().Life -= _damage;
        }
        DestryBullet();
    }

    void DestryBullet()
    {
        Destroy(gameObject);
    }
    public void HitStopStart()
    {
        _isHitStop = true;
    }

    public void HitStopEnd()
    {
        _isHitStop = false;
    }
}

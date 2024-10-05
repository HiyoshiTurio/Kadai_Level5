using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPlayerState
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("MyDestroy", _lifeTime);
        GetComponent<AABBCollision>().OnAABBEnterEvent += Hit;
    }

    private void FixedUpdate()
    {
        this.transform.position += _speed * _fixedSpeed * transform.up;
    }

    private void MyDestroy()
    {
        ColliderManager.Instance.RemoveAABBCollision(this.gameObject.GetComponent<AABBCollision>());
        Destroy(this.gameObject);
    }

    void Hit(AABBCollision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log($"{other.gameObject.name}");
            HitPlayer(_damage);
            MyDestroy();
        }
    }
    public void HitPlayer(int damage)
    {
    }
}

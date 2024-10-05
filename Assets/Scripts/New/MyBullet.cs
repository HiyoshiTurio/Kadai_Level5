using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    private float _fixedSpeed = 0.01f;
    private MyRigidBody _myRigid;

    private void Awake()
    {
        _myRigid = GetComponent<MyRigidBody>();
    }

    void Start()
    {
        Invoke("MyDestroy", _lifeTime);
    }
    private void FixedUpdate()
    {
        _myRigid.V += transform.up * (_speed * _fixedSpeed);
    }
    private void MyDestroy()
    {
        MyColliderManager.Instance.RemoveCollider(this.GetComponent<MyCollider>());
        Destroy(this.gameObject);
    }

}

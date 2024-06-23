using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    private float _fixedSpeed = 0.01f;

    private void Start()
    {
        Invoke("Destroy", _lifeTime);
    }

    private void FixedUpdate()
    {
        this.transform.position += _speed * _fixedSpeed * transform.up ;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

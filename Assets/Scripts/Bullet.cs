using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _fixedSpeed = 0.01f;

    private void FixedUpdate()
    {
        this.transform.position += _speed * _fixedSpeed * transform.up ;
    }
}

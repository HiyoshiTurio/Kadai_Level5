using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    private MyRigidBody _myRigid;

    private void Start()
    {
        _myRigid = GetComponent<MyRigidBody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 tmp = new Vector3(h, v);
        if(h!= 0 && v!= 0) tmp.Normalize();
        _myRigid.V += new Vector3(tmp.x * moveSpeed,0,0);
        _myRigid.V += new Vector3(0,tmp.y * moveSpeed,0);
    }
}

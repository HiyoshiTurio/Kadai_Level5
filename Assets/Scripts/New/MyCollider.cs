using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollider : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(-0.5f, -0.5f, 0);
    [SerializeField] private float sizeCx = 1f;
    [SerializeField] private float sizeCy = 1f;
    public bool isTrigger  = false;
    private Rect _rect;
    private MyRigidBody _myRigid;
    private static MyColliderManager _colliderManager;

    public Vector3 Pivot
    {
        get => this.transform.position; 
        set => this.transform.position = value;
    }
    public Rect Rect { get => _rect; }

    public Vector3 V
    {
        get => _myRigid.V;
        set => _myRigid.V = value;
    }
    public float Right { get => Pivot.x + sizeCx + offset.x; }
    public float Left { get => Pivot.x + offset.x; }
    public float Top { get => Pivot.y + sizeCy + offset.y; }
    public float Bottom { get => Pivot.y + offset.y; }

    private void Awake()
    {
        _myRigid = this.GetComponent<MyRigidBody>();
        _colliderManager = MyColliderManager.Instance;
    }
    private void Start()
    {
        _colliderManager.AddCollider(GetComponent<MyCollider>());
    }
    private void Update()
    {
        UpDateRect();
    }
    private void UpDateRect()
    {
        _rect = new Rect(
            Right,
            Left,
            Top,
            Bottom
        );
    }
    private void OnDrawGizmos()
    {
        UpDateRect();
        Debug.DrawLine(new Vector3(Left,Bottom), new Vector3(Left,Top),Color.green);
        Debug.DrawLine(new Vector3(Left,Top), new Vector3(Right,Top),Color.green);
        Debug.DrawLine(new Vector3(Right,Top), new Vector3(Right,Bottom),Color.green);
        Debug.DrawLine(new Vector3(Right,Bottom), new Vector3(Left,Bottom),Color.green);
    }
}

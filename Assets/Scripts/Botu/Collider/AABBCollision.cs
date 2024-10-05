using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DefaultExecutionOrder(10)]
public class AABBCollision : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float size_cx;
    [SerializeField] private float size_cy;
    private Vector3 _v;
    private Vector3 _pos;
    AABBCollision _collider;
    private Vector3 _pivot;
    private Rect _rect;
    public event Action<AABBCollision> OnAABBEnterEvent;
    public Vector3 Pivot
    {
        get => _pivot; 
        set => _pivot = value;
    }
    public Rect Rect
    {
        get => _rect;
    }

    public Vector3 V
    {
        get => _v;
    }

    public float Right { get => Pivot.x + size_cx + offset.x; }
    public float Left { get => Pivot.x + offset.x; }
    public float Top { get => Pivot.y + size_cy + offset.y; }
    public float Bottom { get => Pivot.y + offset.y; }

    private void Awake()
    {
        _collider = this;
    }

    private void Start()
    {
        UpDateRect();
        ColliderManager.Instance.AddAABBCollision(_collider);
    }
    private void Update() 
    {
        UpDateRect();
    }

    private void FixedUpdate()
    {
        _v = transform.position - _pos;
        _pos = transform.position;
    }

    public void OnAABBEnter(AABBCollision other)
    {
        OnAABBEnterEvent?.Invoke(other);
    }

    private void UpDateRect()
    {
        _pivot = transform.position;
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



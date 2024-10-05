using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AABBCollision : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float size_cx;
    [SerializeField] private float size_cy;
    AABBCollision _collider;
    private Vector3 _pivot;
    private Rect _rect;
    public Vector3 Pivot
    {
        get => _pivot;
        private set => _pivot = value;
    }
    public Rect Rect
    {
        get => _rect;
    }

    public float Right { get => Pivot.x + size_cx + offset.x; }
    public float Left { get => Pivot.x + offset.x; }
    public float Top { get => Pivot.y + size_cy + offset.y; }
    public float Bottom { get => Pivot.y + offset.y; }
    private Action HitAction;

    private void Awake()
    {
        _collider = this;
    }

    void Start()
    {
        ColliderManager.Instance.AddAABBCollision(_collider);
    }
    private void Update() 
    {
        _pivot = transform.position;
        _rect = new Rect(
            Right,
            Left,
            Top,
            Bottom
        );
    }

    public void Hit()
    {
        HitAction?.Invoke();
    }
    private void OnDrawGizmos()
    {
        _pivot = transform.position;
        _rect = new Rect(
            Right,
            Left,
            Top,
            Bottom
        );
        Debug.DrawLine(new Vector3(Left,Bottom), new Vector3(Left,Top),Color.green);
        Debug.DrawLine(new Vector3(Left,Top), new Vector3(Right,Top),Color.green);
        Debug.DrawLine(new Vector3(Right,Top), new Vector3(Right,Bottom),Color.green);
        Debug.DrawLine(new Vector3(Right,Bottom), new Vector3(Left,Bottom),Color.green);
    }
}



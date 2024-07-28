using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollision : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float size_cx;
    [SerializeField] private float size_cy;
    private Vector3 _pivot;

    public Vector3 Pivot
    {
        get => _pivot;
        private set
        {
            _pivot = value;
        }
    }
    private Rect _rect;

    public Rect Rect
    {
        get => _rect;
        set
        {
            _rect = value;
        }
    }

    public float Right
    {
        get => Pivot.x + size_cx + offset.x;
    }

    public float Left
    {
        get => Pivot.x + offset.x;
    }

    public float Top
    {
        get => Pivot.y + size_cy + offset.y;
    }

    public float Bottom
    {
        get => Pivot.y + offset.y;
    }
    private void Start()
    {
        _rect = new Rect(
            Right,
            Left,
            Top,
            Bottom
        );
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawLine(new Vector3(Left,Bottom), new Vector3(Left,Top));
        Gizmos.DrawLine(new Vector3(Left,Top), new Vector3(Right,Top));
        Gizmos.DrawLine(new Vector3(Right,Top), new Vector3(Right,Bottom));
        Gizmos.DrawLine(new Vector3(Right,Bottom), new Vector3(Left,Bottom));
    }
}



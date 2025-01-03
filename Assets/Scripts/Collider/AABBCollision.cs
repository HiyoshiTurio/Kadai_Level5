using System;
using UnityEngine;
[DefaultExecutionOrder(0)]
public class AABBCollision : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float size_cx;
    [SerializeField] private float size_cy;
    AABBCollision _aabbCollision;
    private MyRigidbody _myRigidbody;
    private Rect _rect;
    public Vector3 Pivot { get => this.transform.position; }
    public Rect Rect { get => _rect; }
    public Vector3 V { get => _myRigidbody.V; }

    public float Right { get => Pivot.x + size_cx + offset.x; }
    public float Left { get => Pivot.x + offset.x; }
    public float Top { get => Pivot.y + size_cy + offset.y; }
    public float Bottom { get => Pivot.y + offset.y; }
    public Action<AABBCollision> OnAABBEnterEvent;

    private void Start()
    {
        _aabbCollision = this;
        _myRigidbody = GetComponent<MyRigidbody>();
        ColliderManager.Instance.AddAABBCollision(_aabbCollision);
    }
    private void Update() 
    {
        _rect = new Rect(
            Right,
            Left,
            Top,
            Bottom
        );
    }
    private void OnDestroy()
    {
        ColliderManager.Instance.RemoveAABBCollision(this);
    }
    public void Hit(AABBCollision collision)
    {
        OnAABBEnterEvent?.Invoke(collision);
    }

    public void DebugText()
    {
        Debug.Log($"{gameObject.name}");
    }

    private void OnDrawGizmos()
    {
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



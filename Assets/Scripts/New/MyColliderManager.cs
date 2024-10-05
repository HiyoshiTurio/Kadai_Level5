using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-10)]
public class MyColliderManager : MonoBehaviour
{
    List<MyCollider> _myColliders = new List<MyCollider>();
    static MyColliderManager _instance;

    public static MyColliderManager Instance
    {
        get => _instance;
    }

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (_myColliders.Count > 1)
        {
            for (int i = 0; i < _myColliders.Count; i++)
            {
                MyCollider collider1 = _myColliders[i];
                for (int j = i + 1; j < _myColliders.Count; j++)
                {
                    MyCollider collider2 = _myColliders[j];
                    if (CheckCollisions(collider1, collider2))
                    {
                        //Debug.Log($"{collider1.gameObject.name} {collider2.gameObject.name}");
                        if(!collider1.isTrigger) TmpMethod(collider1, collider2);
                        if (!collider2.isTrigger) TmpMethod(collider2, collider1);
                    }
                }
            }
        }
    }

    public void AddCollider(MyCollider collider) { _myColliders.Add(collider); }
    public void RemoveCollider(MyCollider collider) { _myColliders.Remove(collider);}

    bool CheckCollisions(MyCollider collider1, MyCollider collider2)
    {
        Rect rect1 = collider1.Rect;
        Vector3 v1 = collider1.V;
        Rect rect2 = collider2.Rect;
        Vector3 v2 = collider2.V;
        Vector3 point = new Vector3(rect1.Left, rect1.Bottom - v1.y - v2.y);
        
        
        Rect exRect = new Rect(
            rect2.Right,
            rect2.Left - (rect1.Right - rect1.Left),
            rect2.Top,
            rect2.Bottom - (rect1.Top - rect1.Bottom));
        
        if (point.x < exRect.Right && point.x > exRect.Left && point.y < exRect.Top && point.y > exRect.Bottom)
        {
            return true;
        }

        return false;
    }
    void TmpMethod(MyCollider collision1, MyCollider collision2)
    {
        Rect aabb1 = collision1.Rect;
        Rect aabb2 = collision2.Rect;
        collision1.Pivot = new Vector2(collision1.Pivot.x, aabb2.Top + (aabb1.Top - collision1.Pivot.y));
    }
}
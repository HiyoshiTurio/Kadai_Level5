using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[DefaultExecutionOrder(100)]
public class ColliderManager : MonoBehaviour
{
    [SerializeField] float num = 0.0f;
    static ColliderManager _instance;

    List<AABBCollision> AABBCollisions = new List<AABBCollision>();

    public static ColliderManager Instance
    {
        get => _instance;
    }

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (AABBCollisions.Count > 1)
        {
            for (int i = 0; i < AABBCollisions.Count; i++)
            {
                AABBCollision collision1 = AABBCollisions[i];
                for (int j = i + 1; j < AABBCollisions.Count; j++)
                {
                    AABBCollision collision2 = AABBCollisions[j];
                    if (CheckAABB(collision1, collision2))
                    {
                        Debug.Log(
                            $"{collision1.gameObject.name} {collision1.transform.position},{collision2.gameObject.name} {collision2.transform.position}");
                        collision1.OnAABBEnter(collision2);
                        collision2.OnAABBEnter(collision1);
                    }
                }
            }
        }
    }

    public void AddAABBCollision(AABBCollision collision)
    {
        AABBCollisions.Add(collision);
    }

    public void RemoveAABBCollision(AABBCollision collision)
    {
        AABBCollisions.Remove(collision);
    }

    //参考URL:https://taiyakisun.hatenablog.com/entry/20120205/1328410006
    bool CheckAABB(AABBCollision collision1, AABBCollision collision2)
    {
        Rect aabb1 = collision1.Rect;
        Vector3 v1 = collision1.V;
        Rect aabb2 = collision2.Rect;
        Vector3 v2 = collision2.V;
        Vector3 rv = v1 - v2;

        Vector3 p0 = new Vector3(aabb1.Left, aabb1.Bottom);
        Rect exAABB2 = new Rect
        (
            aabb2.Right,
            aabb2.Left - (aabb1.Right - aabb1.Left),
            aabb2.Top,
            aabb2.Bottom - (aabb1.Top - aabb1.Bottom));

        //if (rv.x != 0)
        {
            float fLineX = rv.x > 0 ? exAABB2.Left : exAABB2.Right;
            float t = (fLineX - (p0.x + rv.x)) / rv.x;

            if (t >= 0 && t <= num)
            {
                float hitY = p0.y + t * rv.y;
                if (hitY >= exAABB2.Bottom && hitY <= exAABB2.Top)
                {
                    return true;
                }
            }
        }

        //if (rv.y != 0)
        {
            float fLineY = rv.y > 0 ? exAABB2.Bottom : exAABB2.Top;
            float t = (fLineY - (p0.y + rv.y)) / rv.y;

            if (t >= 0 && t <= num)
            {
                float hitX = p0.x + t * rv.x;
                if ((hitX >= exAABB2.Left) && (hitX <= exAABB2.Right))
                {
                    return true;
                }
            }
        }

        return false;
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderManager : MonoBehaviour
{
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
                    AABBCollision collision2 =
                        i == AABBCollisions.Count - 1 ? AABBCollisions[0] : AABBCollisions[j];
                    if (CheckAABB(collision1, collision2))
                    {
                        Debug.Log(collision1.gameObject.name + " and " + collision2.gameObject.name + " collided");
                        collision1.Hit();
                        collision2.Hit();
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
    private bool CheckAABB(AABBCollision collision1, AABBCollision collision2)
    {
        Debug.Log("CheckAABB");
        Rect aabb1 = collision1.Rect;
        Vector3 v1 = collision1.V;
        Rect aabb2 = collision2.Rect;
        Vector3 v2 = collision2.V;
        
        Vector3 rv = v1 - v2;
        Vector3 point = new Vector3(aabb1.Left, aabb1.Bottom);

        Rect exAABB = new Rect
        (
            aabb2.Right,
            aabb2.Left - (aabb1.Right - aabb1.Left),
            aabb2.Top,
            aabb2.Bottom - (aabb1.Top - aabb1.Bottom)
        );
        if (rv.x != 0)
        {
            Debug.Log("a");
            float fLineX = (rv.x > 0) ? exAABB.Left : exAABB.Right;
            float t = (fLineX - (point.x + rv.x)) / rv.x;

            if (t >= 0 && t <= 1.0f)
            {
                Debug.Log("b");
                float hitY = point.y + t * rv.y;
                if (hitY >= exAABB.Bottom && hitY <= exAABB.Top)
                {
                    Debug.Log("c");
                    return true;
                }
            }
        }

        if (rv.y != 0)
        {
            Debug.Log("d");
            float fLineY = (rv.y > 0) ? exAABB.Bottom : exAABB.Top;
            float t = (fLineY - (point.y + rv.y)) / rv.y;

            if ((t >= 0) && (t <= 1.0f))
            {
                Debug.Log("e");
                float hitX = point.x + t * rv.x;
                if ((hitX >= exAABB.Left) && (hitX <= exAABB.Right))
                {
                    Debug.Log("f");
                    return true;
                }
            }
        }

        return false;
    }
}
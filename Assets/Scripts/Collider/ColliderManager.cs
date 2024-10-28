using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderManager : MonoBehaviour
{
    static ColliderManager _instance;
    public static ColliderManager Instance => _instance;
    List<AABBCollision> AABBCollisions = new List<AABBCollision>();

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
                    if (CheckAABBEnter(collision1, collision2))
                    {
                        collision1.Hit(collision2);
                        collision2.Hit(collision1);
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
    private bool CheckAABBEnter(AABBCollision collision1, AABBCollision collision2)
    {
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
            float fLineX = (rv.x > 0) ? exAABB.Left : exAABB.Right;
            float t = (fLineX - (point.x + rv.x)) / rv.x;

            if (t >= 0 && t <= 1.0f)
            {
                float hitY = point.y + t * rv.y;
                if (hitY >= exAABB.Bottom && hitY <= exAABB.Top)
                {
                    return true;
                }
            }
        }

        if (rv.y != 0)
        {
            float fLineY = (rv.y > 0) ? exAABB.Bottom : exAABB.Top;
            float t = (fLineY - (point.y + rv.y)) / rv.y;

            if ((t >= 0) && (t <= 1.0f))
            {
                float hitX = point.x + t * rv.x;
                if ((hitX >= exAABB.Left) && (hitX <= exAABB.Right))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool AABBExit(AABBCollision collision1, AABBCollision collision2) //未完成
    {
        Rect aabb1 = collision1.Rect;
        Vector3 v1 = collision1.V;
        Rect aabb2 = collision2.Rect;
        Vector3 v2 = collision2.V;

        Vector3 rv = v2 - v1;

        if (v2.x != 0)
        {
            float collision1X;
            float collision2X;
            if (rv.x > 0)
            {
                collision1X = collision1.Left;
                collision2X = collision2.Right;
            }
            else
            {
                collision1X = collision1.Right;
                collision2X = collision2.Left;
            }
            
        }

        return false;
    }

    public void CheckRaser(Vector3 pivot, Vector3 direction, Raser raser)
    {
        for (int i = 0; i < AABBCollisions.Count; i++)
        {
            if (CheckRaserIsHit(pivot, direction, AABBCollisions[i]))
            {
                raser.Hit(AABBCollisions[i]);
            }
        }
    }
    bool CheckRaserIsHit(Vector2 pivot, Vector2 direction, AABBCollision collision)
    {
        Vector2 p1;
        Vector2 p2;
        if (direction.x > 0)
        {
            if (direction.y > 0)
            {
                p1 = new Vector2(collision.Rect.Left, collision.Rect.Top);
                p2 = new Vector2(collision.Rect.Right, collision.Rect.Bottom);
            }
            else
            {
                p1 = new Vector2(collision.Rect.Right, collision.Rect.Top);
                p2 = new Vector2(collision.Rect.Left, collision.Rect.Bottom);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                p1 = new Vector2(collision.Rect.Left, collision.Rect.Bottom);
                p2 = new Vector2(collision.Rect.Right, collision.Rect.Top);
            }
            else
            {
                p1 = new Vector2(collision.Rect.Right, collision.Rect.Bottom);
                p2 = new Vector2(collision.Rect.Left, collision.Rect.Top);
            }
        }

        Vector2 tmp = new Vector2(-direction.y, direction.x);
        float dot1 = Vector2.Dot((p1 - pivot), tmp);
        float dot2 = Vector2.Dot((p2 - pivot), tmp);
        if (dot2 < 0 && dot1 > 0)
        {
            return true;
        }
        return false;
    }
}
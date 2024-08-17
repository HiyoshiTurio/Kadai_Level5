using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)]
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
                AABBCollision collision2 = i == AABBCollisions.Count - 1 ? AABBCollisions[0] : AABBCollisions[i + 1];
                Debug.Log(collision1.gameObject.name + " and " + collision2.gameObject.name + " collided");
                if (CheckAABB(collision1, collision2))
                {
                    Debug.Log("hit");
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
        Vector3 v1 = collision1.Pivot;
        Rect aabb2 = collision2.Rect;
        Vector3 v2 = collision2.Pivot;
        Vector3 rv = v1 - v2;
        Vector3 p0 = new Vector3(aabb1.Left, aabb1.Bottom);

        Rect exAABB1 = new Rect
        (
            aabb2.Right,
            aabb2.Left - (aabb1.Right - aabb1.Left),
            aabb2.Top,
            aabb2.Bottom - (aabb1.Top - aabb1.Bottom)
        );
        if (rv.x != 0)
        {
            float fLineX = (rv.x > 0) ? exAABB1.Left : exAABB1.Right;
            float t = fLineX - (p0.x + rv.x) / rv.x;

            if (t >= 0 && t <= 1.0f)
            {
                float hitY = p0.y + t * rv.y;
                if (hitY >= exAABB1.Bottom && hitY <= exAABB1.Top)
                {
                    return true;
                }
            }
        }
        if (rv.y != 0)
        {
            float fLineY = (rv.y > 0) ? exAABB1.Bottom : exAABB1.Top;
            float t = fLineY - (p0.y + rv.y) / rv.y;

            if ((t >= 0) && (t <= 1.0f))
            {
                float hitX = p0.x + t * rv.x;
                if ((hitX >= exAABB1.Left) && (hitX <= exAABB1.Right))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
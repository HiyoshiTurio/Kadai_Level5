using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 1;
    private AABBCollision _bulletAABB;
    private float _fixedSpeed = 0.01f;
    
    private void Start()
    {
        Invoke("Destroy", _lifeTime);
        _bulletAABB = GetComponent<AABBCollision>();
    }

    private void Update()
    {
        if (CheckAABB(_bulletAABB.Rect, _speed * _fixedSpeed * transform.up))
        {
            Hit();
        }
    }

    private void FixedUpdate()
    {
        this.transform.position += _speed * _fixedSpeed * transform.up;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    void Hit()
    {
        Destroy(this.gameObject);
    }

    
    
    public bool CheckAABB(Rect AABB0, Vector3 v0)
    {
        EnemyManager enemyManager = EnemyManager.Instance;
        Rect AABB1 = enemyManager.playerRect;
        Vector3 v1 = enemyManager.PlayerVec;
        Debug.Log($"v0{v0}, v1{v1}");
        Vector3 rv = v0 - v1;

        Vector3 p0 = new Vector3(AABB0.Left, AABB0.Bottom);
        
        Rect exAABB1 = new Rect
        (
            AABB1.Right,
            AABB1.Left - (AABB0.Right - AABB0.Left),
            AABB1.Top,
            AABB1.Bottom - (AABB0.Top - AABB0.Bottom)
        );

        if (rv.x != 0)
        {
            float fLineX = (rv.x > 0) ? exAABB1.Left : exAABB1.Right;
            float t = (fLineX - (p0.x + rv.x)) / rv.x;

            if (t >= 0 && t <= 1.0f)
            {
                float hitY = p0.y + t * rv.y;
                if (hitY >= exAABB1.Bottom && hitY <= exAABB1.Top)
                {
                    Debug.Log("A1");
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
                    Debug.Log("A2");
                    return true;
                }
            }
        }

        return false;
    }
}

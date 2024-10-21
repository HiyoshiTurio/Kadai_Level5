using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    [SerializeField] private int healingAmount = 2;

    private void Start()
    {
        GetComponent<AABBCollision>().OnAABBEnterEvent += HitPlayer;
    }

    void HitPlayer(AABBCollision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerState>().Life += healingAmount;
            Destroy(gameObject);
        }
    }
}

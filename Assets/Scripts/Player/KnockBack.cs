using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : CharacterBase
{
    [SerializeField] private float _knockBackTime = 8f;
    [SerializeField] private float _knockBackForce = 1f;

    private void Start()
    {
        Collision.OnAABBEnterEvent += KnockbackStart;
    }

    public void KnockbackStart(AABBCollision hitObject)
    {
        StartCoroutine(KnockBackAction(Collision, hitObject, Rb));
    }

    IEnumerator KnockBackAction(AABBCollision character, AABBCollision hitObject, MyRigidbody rb)
    {
        Vector3 p1 = character.Pivot;
        Vector3 p2 = hitObject.Pivot;

        Vector3 dic = new Vector3(0.05f * _knockBackForce, 0, 0);
        if (p1.x < p2.x) dic.x = -dic.x;
        
        for (float timer = _knockBackTime; timer > 0f; timer--)
        {
            rb.AddSpeed(dic);
            yield return null;
        }
    }
}

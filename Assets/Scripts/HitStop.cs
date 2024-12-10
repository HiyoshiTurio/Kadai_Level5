using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitStop : ActionBase
{
    [SerializeField] private float stopFrame = 30.0f;

    protected override void AABBCollisionEnterAction(AABBCollision aabbCollision)
    {
        StartCoroutine(HitStopAction());
    }

    IEnumerator HitStopAction()
    {
        _characterBase._isHitStop = true;
        for (int i = 0; i < stopFrame; i++)
        {
            yield return null;
        }
        _characterBase._isHitStop = false;
    }
}

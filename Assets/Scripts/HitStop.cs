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
        CharacterBase._isHitStop = true;
        for (int i = 0; i < stopFrame; i++)
        {
            yield return null;
        }
        CharacterBase._isHitStop = false;
    }
}

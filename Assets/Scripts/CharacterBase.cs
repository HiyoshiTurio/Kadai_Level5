using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private void Awake()
    {
        if (GetComponent<AABBCollision>())
        {
            GetComponent<AABBCollision>().OnAABBEnterEvent += AABBCollisionEnter;
        }
    }

    protected virtual void AABBCollisionEnter(AABBCollision collision) { }
}

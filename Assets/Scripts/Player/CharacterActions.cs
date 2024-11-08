using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private float _knockBackTime = 8f;
    [SerializeField] private float _knockBackForce = 1f;
    public void KnockbackStart(AABBCollision character, AABBCollision hitObject, TmpRigidbody rb)
    {
        StartCoroutine(KnockBackAction(character, hitObject, rb));
    }

    IEnumerator KnockBackAction(AABBCollision character, AABBCollision hitObject, TmpRigidbody rb)
    {
        Debug.Log("Knockback Start");
        Vector3 p1 = character.Pivot;
        Vector3 p2 = hitObject.Pivot;
        float angle = 0f;
        for (float timer = _knockBackTime; timer > 0f; timer--, angle += 2)
        {
            rb.AddSpeed(new Vector3(-0.05f * _knockBackForce,0,0));
            yield return null;
        }
        Debug.Log("Knockback End");
    }
}

using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private float _knockBackTime = 8f;
    private float _knockBackForce = 10f;
    private float _timer = 0f;

    public void KnockbackStart(AABBCollision character, AABBCollision hitObject, TmpRigidbody rb)
    {
        _timer = _knockBackTime;
        StartCoroutine(KnockBackAction(character, hitObject, rb));
    }

    IEnumerator KnockBackAction(AABBCollision character, AABBCollision hitObject, TmpRigidbody rb)
    {
        Vector3 p1 = character.Pivot;
        Vector3 p2 = hitObject.Pivot;
        float angle = 0f;
        for (_timer = _knockBackTime; _timer > 0f; _timer--, angle += 2)
        {
            //rb.XSpeed = (float)(Math.Cos(angle) * _knockBackForce);
            yield return null;
        }
    }
}

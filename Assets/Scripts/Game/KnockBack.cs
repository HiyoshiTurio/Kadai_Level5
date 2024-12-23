using System.Collections;
using UnityEngine;

public class KnockBack : ActionBase
{
    [SerializeField] private float _knockBackTime = 8f;
    [SerializeField] private float _knockBackForce = 1f;
    [SerializeField] bool _isSuperArmor = false;
    MyRigidbody Rb => CharacterBase.GetRb();

    private bool IsStunned
    {
        get => CharacterBase._isStunned;
        set => CharacterBase._isStunned = value;
    }

    protected override void AABBCollisionEnterAction(AABBCollision hitObject)
    {
        if (IsStunned && _isSuperArmor)
            return;
        if(hitObject.gameObject.CompareTag("Bullet"))
            StartCoroutine(KnockBackAction(Collision, hitObject, Rb));
    }

    IEnumerator KnockBackAction(AABBCollision character, AABBCollision hitObject, MyRigidbody rb)
    {
        IsStunned = true;
        Vector3 p1 = character.Pivot;
        Vector3 p2 = hitObject.Pivot;

        Vector3 dic = new Vector3(0.05f * _knockBackForce, 0, 0);
        if (p1.x < p2.x) dic.x = -dic.x;
        
        for (float timer = _knockBackTime; timer > 0f; timer--)
        {
            rb.AddSpeed(dic);
            yield return null;
        }
        rb.AddSpeed(Vector3.zero);
        IsStunned = false;
    }
}

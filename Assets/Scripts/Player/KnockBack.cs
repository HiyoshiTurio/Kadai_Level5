using System.Collections;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float _knockBackTime = 8f;
    [SerializeField] private float _knockBackForce = 1f;
    CharacterBase _character;
    MyRigidbody Rb => _character.GetRb();
    AABBCollision Collision => _character.GetCollision();

    private bool IsStunned
    {
        get => _character.IsStunned;
        set => _character.IsStunned = value;
    }

    private void Start()
    {
        _character = GetComponent<CharacterBase>();
        Collision.OnAABBEnterEvent += KnockbackStart;
    }

    public void KnockbackStart(AABBCollision hitObject)
    {
        IsStunned = true;
        if(hitObject.gameObject.CompareTag("Bullet"))
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
        IsStunned = false;
    }
}

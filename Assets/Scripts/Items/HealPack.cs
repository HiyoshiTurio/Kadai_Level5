using UnityEngine;

public class HealPack : ItemBase
{
    [SerializeField] int healAmount = 2;
    protected override void HitAction(AABBCollision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerState>().Life += healAmount;
        }
    }
}

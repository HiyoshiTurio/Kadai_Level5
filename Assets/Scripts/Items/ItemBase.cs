using UnityEngine;

public class ItemBase : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AABBCollision>().OnAABBEnterEvent += HitPlayer;
    }

    void HitPlayer(AABBCollision collision)
    {
        HitAction(collision);
        Destroy(gameObject);
    }

    protected virtual void HitAction(AABBCollision collision)
    {
    }
}
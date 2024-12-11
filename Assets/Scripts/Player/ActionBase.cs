using UnityEngine;

public class ActionBase : MonoBehaviour
{
    protected CharacterBase CharacterBase;
    protected AABBCollision Collision;
    private void Start()
    {
        CharacterBase = GetComponent<CharacterBase>();
        Collision = CharacterBase.GetCollision();
        Collision.OnAABBEnterEvent += AABBCollisionEnterAction;
    }

    protected virtual void AABBCollisionEnterAction(AABBCollision aabbCollision){}
}

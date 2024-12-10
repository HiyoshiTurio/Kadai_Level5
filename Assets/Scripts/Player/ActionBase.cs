using UnityEngine;

public class ActionBase : MonoBehaviour
{
    protected CharacterBase _characterBase;
    protected AABBCollision _collision;
    private void Start()
    {
        _characterBase = GetComponent<CharacterBase>();
        _collision = _characterBase.GetCollision();
        _collision.OnAABBEnterEvent += AABBCollisionEnterAction;
    }

    protected virtual void AABBCollisionEnterAction(AABBCollision aabbCollision){}
}

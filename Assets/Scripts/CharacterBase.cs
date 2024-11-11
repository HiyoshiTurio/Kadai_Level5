using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private protected MyRigidbody Rb = null;
    private protected AABBCollision Collision = null;
    
    private void Awake()
    {
        if (GetComponent<MyRigidbody>()) Rb = GetComponent<MyRigidbody>();
        if (GetComponent<AABBCollision>()) Collision = GetComponent<AABBCollision>();
        if (Collision != null) GetComponent<AABBCollision>().OnAABBEnterEvent += AABBCollisionEnter;
    }

    protected virtual void AABBCollisionEnter(AABBCollision collision) { }
}

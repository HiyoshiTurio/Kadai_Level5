using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private protected MyRigidbody Rb = null;
    private protected AABBCollision Collision = null;
    private protected bool _isStunned = false;
    public MyRigidbody GetRb() { return Rb; }
    public AABBCollision GetCollision() { return Collision; }
    public bool IsStunned { get { return _isStunned; } set { _isStunned = value; } }
    
    private void Awake()
    {
        if (GetComponent<MyRigidbody>()) Rb = GetComponent<MyRigidbody>();
        if (GetComponent<AABBCollision>()) Collision = GetComponent<AABBCollision>();
        if (Collision != null) GetComponent<AABBCollision>().OnAABBEnterEvent += AABBCollisionEnter;
    }

    protected virtual void AABBCollisionEnter(AABBCollision collision) { }
}

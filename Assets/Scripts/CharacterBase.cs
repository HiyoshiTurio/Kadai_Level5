using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBase : MonoBehaviour
{
    private protected MyRigidbody Rb = null;
    private protected AABBCollision Collision = null;
    public bool _isStunned = false;
    private bool _isHitStop = false;

    public bool IsHitStop
    {
        get { return _isHitStop; }
        set
        {
            _isHitStop = value;
            Debug.Log("IsHitStop: " + _isHitStop);
        }
    }
    public MyRigidbody GetRb() { return Rb; }
    public AABBCollision GetCollision() { return Collision; }
    
    private void Awake()
    {
        if (GetComponent<MyRigidbody>()) Rb = GetComponent<MyRigidbody>();
        if (GetComponent<AABBCollision>()) Collision = GetComponent<AABBCollision>();
        if (Collision != null) GetComponent<AABBCollision>().OnAABBEnterEvent += AABBCollisionEnter;
    }

    protected virtual void AABBCollisionEnter(AABBCollision collision) { }
}

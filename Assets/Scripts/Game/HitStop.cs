using UnityEngine;

public class HitStop : ActionBase, IHitStop
{
    IHitStop _iHitStop;
    private MyRigidbody _rb;
    void Awake()
    {
        _iHitStop = this;
        IHitStop.RegisterHitStopObject(_iHitStop);
        _rb = GetComponent<MyRigidbody>();
    }
    protected override void AABBCollisionEnterAction(AABBCollision aabbCollision)
    {
        IHitStop.HitStop();
    }
    public void StartHitStop()
    {
        CharacterBase.IsHitStop = true;
        _rb.AddSpeed(Vector3.zero);
    }
    public void StopHitStop()
    {
        CharacterBase.IsHitStop = false;
    }
    private void OnDestroy()
    {
        IHitStop.UnregisterHitStopObject(this);
    }
}

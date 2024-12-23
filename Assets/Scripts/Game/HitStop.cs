using UnityEngine;

public class HitStop : ActionBase, IHitStop
{
    IHitStop _iHitStop;
    void Start()
    {
        _iHitStop = this;
        IHitStop.RegisterHitStopObject(_iHitStop);
    }
    protected override void AABBCollisionEnterAction(AABBCollision aabbCollision)
    {
        AABBCollision other = aabbCollision;
        Debug.Log("HitStop Collision Enter");
        IHitStop.HitStop();
    }
    public void StartHitStop()
    {
        CharacterBase._isHitStop = true;
    }
    public void StopHitStop()
    {
        CharacterBase._isHitStop = false;
    }
    private void OnDestroy()
    {
        IHitStop.UnregisterHitStopObject(this);
    }
}

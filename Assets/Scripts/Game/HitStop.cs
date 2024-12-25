public class HitStop : ActionBase, IHitStop
{
    IHitStop _iHitStop;
    void Awake()
    {
        _iHitStop = this;
        IHitStop.RegisterHitStopObject(_iHitStop);
    }
    protected override void AABBCollisionEnterAction(AABBCollision aabbCollision)
    {
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

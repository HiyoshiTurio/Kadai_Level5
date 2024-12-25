using UnityEngine;

public interface IHitStop
{
    void StartHitStop();
    void StopHitStop();
    public static void HitStop()
    {
        HitStopManager.Instance.HitStop();
        Debug.Log("Interface IHitStop Invoked");
    }
    public static void RegisterHitStopObject(IHitStop hitStopObject)
    {
        HitStopManager.RegisterHitStopObject(hitStopObject);
    }
    public static void UnregisterHitStopObject(IHitStop hitStopObject)
    {
        HitStopManager.UnregisterHitStopObject(hitStopObject);
    }
}

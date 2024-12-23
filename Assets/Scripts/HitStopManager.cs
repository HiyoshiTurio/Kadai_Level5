using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopManager : MonoBehaviour
{ 
    [SerializeField] float hitStopDuration = 0.1f;
    private List<IHitStop> _hitStopObjects = new List<IHitStop>();
    static HitStopManager _instance = null;
    public static HitStopManager Instance{ get { return _instance; }}

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    public static void RegisterHitStopObject(IHitStop hitStopObject)
    {
        _instance._hitStopObjects.Add(hitStopObject);
    }

    public static void UnregisterHitStopObject(IHitStop hitStopObject)
    {
        _instance._hitStopObjects.Remove(hitStopObject);
    }

    public void HitStop()
    {
        Debug.Log("Invoke HitStop");
        StartCoroutine(HitStopAction());
    }
    IEnumerator HitStopAction()
    {
        foreach (IHitStop variable in _hitStopObjects) variable.StartHitStop();
        for (int i = 0; i < hitStopDuration; i++)
        {
            yield return null;
        }
        foreach (IHitStop variable in _hitStopObjects) variable.StopHitStop();
    }
}

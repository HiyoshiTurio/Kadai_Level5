using System.Collections;
using System.Collections.Generic;

interface IHitStop
{
    void HitStopStart();
    void HitStopEnd();
}

class HitStop2
{
    private float stopFrame = 30.0f;

    void StartHitStop()
    {
        
    }

    IEnumerator HitStopAction()
    {
        for (int i = 0; i < stopFrame; i++)
        {
            yield return null;
        }
    }
}
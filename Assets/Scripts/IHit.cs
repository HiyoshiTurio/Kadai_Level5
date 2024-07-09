using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHit
{
    void HitPlayer(int damage)
    {
        PlayerState playerState = PlayerState.Instance;
        playerState.Life -= damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatasManager : MonoBehaviour
{
    [SerializeField] private int _life = 5;
    [SerializeField] private int _atk = 1;

    public int Life
    {
        get => _life;
        set
        {
            _life = value;
        }
    }

    public int Atk
    {
        get => _atk;
        set
        {
            _atk = value;
        }
    }
}

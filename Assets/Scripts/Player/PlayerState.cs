using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int maxLife = 5;
    [SerializeField] private int atk = 1;
    [SerializeField] private Text text;
    private int _life = 0;
    
    public int Life
    {
        get => _life;
        set
        {
            _life = value;
            Debug.Log($"HP{_life}");
            UpdateText();
        }
    }

    public int Atk
    {
        get => atk;
        set
        {
            atk = value;
        }
    }

    void Start()
    {
        UpdateText();
        _life = maxLife;
    }

    void UpdateText()
    {
        text.text = Life.ToString();
    }
}

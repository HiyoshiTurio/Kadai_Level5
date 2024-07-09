using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private static PlayerState _instance;
    [SerializeField] private int _life = 5;
    [SerializeField] private int _atk = 1;
    [SerializeField] private Text _text;

    public static PlayerState Instance
    {
        get { return _instance; }
        private set
        {
            _instance = value;
        }
    }
    
    public int Life
    {
        get => _life;
        set
        {
            _life = value;
            UpdateText();
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

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateText();
    }
    void Update()
    {
        
    }

    void UpdateText()
    {
        _text.text = Life.ToString();
    }
}

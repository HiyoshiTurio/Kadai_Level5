using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int maxLife = 5;
    [SerializeField] private int atk = 1;
    [SerializeField] private Text text;
    [SerializeField] bool Muteki = false;
    private int _life = 0;
    
    public int Life
    {
        get => _life;
        set
        {
            if (!Muteki)
            {
                _life = value;
                UpdateText();
            }
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
        Life = maxLife;
    }

    void UpdateText()
    {
        text.text = Life.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour, IAddDamage
{
    [SerializeField] private int maxLife = 5;
    [SerializeField] private int atk = 1;
    [SerializeField] private Text text;
    [SerializeField] bool Muteki = false;
    private int _hp = 0;
    
    public int Hp
    {
        get => _hp;
        set
        {
            if (!Muteki)
            {
                _hp = value;
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
        Hp = maxLife;
        UpdateText();
    }

    void UpdateText()
    {
        text.text = Hp.ToString();
    }

    public void AddDamage(int damage)
    {
        Hp -= damage;
        Debug.Log("HitPlayer");
    }
}

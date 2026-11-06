using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int BaseHP = 3;
    private const int PointsForAddsBonusHP = 10000;

    [SerializeField] float invulnerabilityTime = 1f;

    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int LostHP => MaxHP - HP;
    public bool IsDead => HP <= 0;

    public event Action Changed;
    public event Action Died;

    float invulnerableUntil;

    void Awake()
    {
        MaxHP = BaseHP + RunData.LastScore / PointsForAddsBonusHP;
        HP = MaxHP;
    }

    public void TakeDamage(int amount)
    {
        if (!IsDead && !(Time.time < invulnerableUntil))
        {
            HP = Math.Max(0, HP - amount);
            invulnerableUntil = Time.time + invulnerabilityTime;
            Changed?.Invoke();

            if (IsDead)
                Died?.Invoke();
        }
        
    }

    public void Heal(int amount)
    {
        if(!IsDead)
        {
            HP = Math.Min(MaxHP, HP + amount);
            Changed?.Invoke();
        }
    }
}

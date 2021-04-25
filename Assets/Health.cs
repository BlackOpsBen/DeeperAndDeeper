using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    private int currentHP;
    private IDie deathBehavior;
    private IHit hurtBehavior;

    private void Start()
    {
        deathBehavior = GetComponent<IDie>();
        hurtBehavior = GetComponent<IHit>();
        currentHP = maxHP;
    }

    public void ModifyHealth(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Min(maxHP, currentHP);
        if (currentHP < 1)
        {
            Die();
        }
        else if (amount < 0)
        {
            hurtBehavior.TriggerHitBehavior();
        }
    }

    public void SetHealth(int newHP)
    {
        currentHP = newHP;
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (currentHP < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        deathBehavior.Die();
    }

    public int GetCurrentHealth()
    {
        return currentHP;
    }

    public void ResetHealth()
    {
        currentHP = maxHP;
    }
}

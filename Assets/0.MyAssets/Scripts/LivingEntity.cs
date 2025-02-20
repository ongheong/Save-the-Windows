using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float health { get; set; }
    public float originHealth { get; set; }

    protected bool isDie;

    public event System.Action OnDeath;
    public int Price;
    public int OriginPrice;
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDie)
        {
            GameManagers.instance.AddMoney(Price);
            Die();
        }

    }

    public virtual void Die()
    {
        isDie = true;

        if (OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }
}

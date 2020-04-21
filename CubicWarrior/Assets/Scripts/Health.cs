using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    public event Action<Health> onUpdated = null;
    public event Action<Health> onDead = null;
    public float CurrHealth => currHealth;
    [SerializeField] float maxHealth = 10;

    [Header("Read Only")]
    [SerializeField] float currHealth = 0;

    void Start()
    {
        currHealth = maxHealth;
        HealthUI ui = FindObjectOfType<HealthUI>();
        ui.Add(this);
    }
    public void TakeDamage(float damage)
    {
        currHealth = currHealth - damage;
        if (currHealth<0)
        {
            onDead?.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            onUpdated?.Invoke(this);
        }
    }
}

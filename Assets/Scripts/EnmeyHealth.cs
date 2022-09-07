using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    private int _currentHealth;
    void Start()
    {
        _currentHealth = _health;
    }

    
    void Update()
    {
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void hurtEnmey(int damage)
    {
        _currentHealth -= damage;
    }

    internal void HurtEnmey(int damageToGive)
    {
        throw new NotImplementedException();
    }
}

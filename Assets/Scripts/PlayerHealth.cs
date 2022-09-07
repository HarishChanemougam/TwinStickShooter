using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _startingHealth;
    [SerializeField]  int _currentHealth;
    [SerializeField] float _flashLength;
    private float _flashCounter;
    private Renderer _rend;
    [SerializeField] Color _storedColor;

   

    void Start()
    {
        _currentHealth = _startingHealth;

        _storedColor = _rend.material.GetColor("Color");

        _rend.GetComponent<Renderer>();
    }

    
    void Update()
    {
        if(_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if(_flashCounter > 0)
        {
            _flashCounter -= Time.deltaTime;
            if(_flashCounter <= 0)
            {
                _rend.material.SetColor("Color", _storedColor);
            }
        }
    }

    private void HurtZone(int damageAmount)
    {
        _currentHealth -= damageAmount;
        _flashCounter = _flashLength;
        _rend.material.SetColor("Color", Color.grey);
    }

}

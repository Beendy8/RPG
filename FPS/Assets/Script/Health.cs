using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Player _player;
    private const int _maxHealth = 5;
    private int _currentHealth;
    private int _armor = 1;
    public int health => _currentHealth;


    private void Start()
    {
        _player.takeDamage += ApplyDamage;
    }
    private void OnDestroy()
    {
        _player.takeDamage -= ApplyDamage;
    }

    public void ApplyDamage(int damage)
    {
        damage -= _armor;
        if (damage < 0) return;
        _currentHealth -= damage;
    }
}

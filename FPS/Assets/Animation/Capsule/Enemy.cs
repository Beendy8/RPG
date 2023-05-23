using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destroy))]
public class Enemy : MonoBehaviour, ITakeDamage
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _takeDamageName;
    [Header("HP"), Space(6)]
    [SerializeField] private int _maxHP;
    private int _currentHP;
    [SerializeField] private Destroy _destroy;
    private void Start()
    {
        _destroy= GetComponent<Destroy>();

        _currentHP = _maxHP;
        _destroy.destroy += () => Destroy(gameObject);
    }
    private void OnDestroy()
    {
        _destroy.destroy -= () => Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        _animator.SetTrigger(_takeDamageName);
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            _destroy.Invoke();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _count = 10;
    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
            Instantiate(_coinPrefab, position, Quaternion.identity).Init(this);
        }
    }

    public event Action takeCoin;
    public void TakeCoin()
    {
        takeCoin?.Invoke();
    }
}

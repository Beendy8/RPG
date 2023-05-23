using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private int _coinNumber;

    private void Start()
    {
        _spawner.takeCoin += AddCoin;
    }
    private void OnDestroy()
    {
        _spawner.takeCoin -= AddCoin;
    }
    private void AddCoin()
    {
        _coinNumber++;
    }
}

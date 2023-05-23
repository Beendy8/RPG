using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Text _text;
    private int _coinNumber;

    private void Start()
    {
        _spawner.takeCoin += AddCoin;
    }
    private void OnDestroy()
    {
        _spawner.takeCoin -= AddCoin;
    }

    public void AddCoin()
    {
        _coinNumber++;
        _text.text = _coinNumber.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    private void OnCollisionEnter(Collision collision)
    {
        _coin.CollisionEnter(collision);
    }
}

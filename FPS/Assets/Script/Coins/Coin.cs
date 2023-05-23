using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Spawner _spawner;
    public void Init(Spawner spawner)
    {
        _spawner = spawner;
    }

    public void CollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.GetComponent<Player>())
        {
            _spawner.TakeCoin();
            Destroy(gameObject);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_fileName", menuName = "Menuaa/Menuiu")]
public class PossibleLoot : ScriptableObject
{
    [SerializeField] private GameObject[] _items;
    public GameObject GetRandomLoot()
    {
        return _items[Random.Range(0, _items.Length)];
    }    
}

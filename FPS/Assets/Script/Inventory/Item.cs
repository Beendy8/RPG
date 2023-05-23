using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_item", menuName = "Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public Sprite sprite { get; private set; }
}

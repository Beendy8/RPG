using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryUI _ui;
    [SerializeField] private List<Item> _items = new List<Item>();

    private void Start()
    {
        Hide();

        for (int i = 0; i < _items.Count; i++)
        {
            _ui.AddItem(_items[i].sprite);
        }
    }

    public void Show()
    {
        _ui.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _ui.gameObject.SetActive(false);
    }
}

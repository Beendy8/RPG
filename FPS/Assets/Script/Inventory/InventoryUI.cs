using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private Transform _content;
    private int _columnCount { get { return _gridLayoutGroup.constraintCount; } }
    [Space(6)]
    [SerializeField] private InventoryCell _cellPrefab;
    private List<InventoryCell> _cells = new List<InventoryCell>();

    public void AddItem(Sprite sprite)
    {
        GetFreeCell().SetSprite(sprite);
    }

    private InventoryCell GetFreeCell()
    {
        int cellCount = _cells.Count;
        for (int i = 0; i < cellCount; i++)
        {
            if (_cells[i]._reserved) continue;
            return _cells[i];
        }
        CreateLine();
        return _cells[cellCount];
    }

    private void CreateLine()
    {
        for (int i = 0; i < _columnCount; i++)
        {
            _cells.Add(Instantiate(_cellPrefab, _content));
        }
    }
}

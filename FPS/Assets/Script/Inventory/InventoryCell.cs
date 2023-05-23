using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    public bool _reserved { get; private set; }
    public void SetSprite(Sprite sprite)
    {
        _reserved = true;
        _image.sprite = sprite;
    }

    public void Clear()
    {
        _reserved = false;
        _image.sprite = null;
    }
}

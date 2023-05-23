using UnityEngine;

public class Controller : MonoBehaviour
{
    [field: SerializeField] public float _mouseSensetivity { get; private set; } = 2;
    [field: SerializeField] public Player _player { get; private set; }
    [field: SerializeField] public Inventory _inventory { get; private set; }
    [field: SerializeField] public CameraController _cameraController { get; private set; }

    private StateController _gameState = new GameController();
    private StateController _inventoryState = new InventoryController();
    private StateController _currentController;

    private void Start()
    {
        SetState(ControllerType.Game);
    }

    private void Update()
    {
        _currentController.Run();
    }

    public void SetState(ControllerType type)
    {
        switch (type)
        {
            case ControllerType.Game:
                _currentController = _gameState;
                break;
            case ControllerType.Inventory:
                _currentController = _inventoryState;
                break;
            default:
                return;
        }

        _currentController.Init(this);
    }
}

public enum ControllerType
{
    None = 0,
    Game = 1,
    Inventory = 2
}

using UnityEditorInternal;
using UnityEngine;

public abstract class StateController
{
    protected Controller _controller;
    public virtual void Init(Controller controller)
    {
        _controller = controller;
    }
    public abstract void Run();
}

public class GameController : StateController
{
    public override void Init(Controller controller)
    {
        base.Init(controller);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Run()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool hit = Input.GetMouseButtonDown(0);
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");

        _controller._player.SetInputAxis(h, v);
        if (hit) _controller._player.Attack();
        _controller._cameraController.SetInputAxis(mX * _controller._mouseSensetivity, mY * _controller._mouseSensetivity);

        if (Input.GetKeyDown(KeyCode.I)) _controller.SetState(ControllerType.Inventory);
    }
}

public class InventoryController : StateController
{
    public override void Init(Controller controller)
    {
        base.Init(controller);

        Cursor.lockState = CursorLockMode.None;
        _controller._inventory.Show();

    }

    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _controller._inventory.Hide();
            _controller.SetState(ControllerType.Game);
        }
    }
}

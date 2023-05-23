using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private Transform _cameraParrent;
    [SerializeField] private float _maxXAngle = 75;
    [SerializeField] private float _minXAngle = 15;
    private float _inputMouseX;
    private float _inputMouseY;
    public void SetInputAxis(float mouseX, float mouseY)
    {
        _inputMouseX = mouseX;
        _inputMouseY = mouseY;
    }
    private void Update()
    {
        RotateCamera();
    }
    private void RotateCamera()
    {
        _cameraPoint.Rotate(0,_inputMouseX,0);

        Vector3 rotation = _cameraParrent.localEulerAngles;
        rotation.x = Mathf.Clamp(rotation.x - _inputMouseY, _minXAngle, _maxXAngle); 
        _cameraParrent.localEulerAngles = rotation; 
    }
}

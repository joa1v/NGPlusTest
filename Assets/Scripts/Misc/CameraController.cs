using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _cinemachineCam;
    [SerializeField] private CinemachineInputAxisController _axisController;

    protected virtual void Update()
    {
        ConstrainController();
    }

    protected virtual void ConstrainController()
    {
        bool mouseDown = Mouse.current.rightButton.isPressed;
        _axisController.enabled = mouseDown;
    }
}

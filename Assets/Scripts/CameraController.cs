using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region AxisNames
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    #endregion

    [SerializeField] private float Sensitivity;
    [SerializeField] private Transform Player;
    [SerializeField] private float VerticalLower;
    [SerializeField] private float VerticalUpper;

    private float _currentVerticalAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        var vertical = -Input.GetAxis(MouseY) * Sensitivity * Time.deltaTime;
        var horizontal = Input.GetAxis(MouseX) * Sensitivity * Time.deltaTime;

        _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle + vertical, VerticalLower, VerticalUpper);
        transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0, 0);

        Player.Rotate(0, horizontal, 0);
    }
}

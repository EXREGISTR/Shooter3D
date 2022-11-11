using UnityEngine;
using Assets.Scripts.PlayerLogic;

namespace Assets.Scripts
{
    internal class CameraMove : MonoBehaviour
    {
        #region AxisNames
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        #endregion

        [SerializeField] private float Sensitivity;
        [SerializeField] private Player Player;
        [SerializeField] private float VerticalLower;
        [SerializeField] private float VerticalUpper;

        private float _currentVerticalAngle;
        private AbstractGun _currentGun;

        private void Start()
        {
            _currentGun = Player.CurrentGun;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void Update()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            var mouseY = Input.GetAxis(MouseY) * Sensitivity * Time.deltaTime;
            var mouseX = Input.GetAxis(MouseX) * Sensitivity * Time.deltaTime;

            _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle - mouseY, VerticalLower, VerticalUpper);
            transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0f, 0f);

            Player.transform.Rotate(0f, mouseX, 0f);

          /*if (_currentGun != Player.CurrentGun)
                _currentGun = Player.CurrentGun;

            if (_currentGun is not null)
                _currentGun.transform.Rotate(0, 0, mouseY);*/
        }
    }
}

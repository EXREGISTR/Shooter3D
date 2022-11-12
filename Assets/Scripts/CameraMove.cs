using UnityEngine;
using Assets.Scripts.PlayerLogic;
using System.Drawing;

namespace Assets.Scripts
{
    internal class CameraMove : MonoBehaviour
    {
        #region AxisNames
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        #endregion

        #region SerializeFields
        [SerializeField] private float Sensitivity;
        [SerializeField] private Player Player;
        [SerializeField] private float VerticalLower;
        [SerializeField] private float VerticalUpper;
        #endregion

        #region PrivateFields
        private AbstractGun _currentGun;
        private float _currentVerticalAngle;
        private float _mouseY;
        private float _mouseX;
        #endregion

        #region UnityMethods
        private void Start()
        {
            _currentGun = Player.CurrentGun;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void Update()
        {
            RotateCamera();
            RotatePlayer();
        }
        private void OnEnable()
        {
            Player.NewGunEvent += OnNewGun;
        }
        private void OnDisable()
        {
            Player.NewGunEvent -= OnNewGun;
        }
        #endregion

        private void RotateCamera()
        {
            _mouseY = -Input.GetAxis(MouseY) * Sensitivity * Time.deltaTime;
            _mouseX = Input.GetAxis(MouseX) * Sensitivity * Time.deltaTime;

            _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle + _mouseY, VerticalLower, VerticalUpper);
            transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0f, 0f);
        }
        private void RotatePlayer()
        {
            Player.transform.Rotate(0f, _mouseX, 0f);
            var rotationPointGun = _currentGun.transform.parent.transform;
            rotationPointGun.transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0f, 0f);
        }
        private void OnNewGun()
        {
            _currentGun = Player.CurrentGun;
        }
    }
}

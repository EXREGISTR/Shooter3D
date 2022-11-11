using UnityEngine;

namespace Assets.Scripts.PlayerLogic
{
    [RequireComponent(typeof(Player))]
    internal class InputController : MonoBehaviour
    {
        #region AxisNames
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private const string Jump = "Jump";
        #endregion

        [SerializeField] private Player Player;
        [SerializeField] private CameraMove CameraMovement;

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                ReadRun();

            else
                ReadWalk();

            if (Input.GetAxis(Jump) > 0)
                ReadJump();

            if (Input.GetMouseButtonDown(0))
                ReadShoot();
        }

        private void ReadWalk()
        {
            Player.Movement.Move(Input.GetAxis(Horizontal), Input.GetAxis(Vertical), isRunning: false);
        }
        private void ReadRun()
        {
            Player.Movement.Move(Input.GetAxis(Horizontal), Input.GetAxis(Vertical), isRunning: true);
        }
        private void ReadJump()
        {
            Player.Movement.Jump();
        }
        private void ReadShoot()
        {
            Player.CurrentGun.Shoot();
        }
    }
}
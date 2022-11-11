using UnityEngine;

namespace Assets.Scripts.PlayerLogic
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        #region SerializeFields
        [SerializeField] private float WalkSpeed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float JumpForce;
        #endregion

        #region PrivateFields
        private Rigidbody _rigidBody;
        private Vector3 _movement;
        private bool _onGround;
        private float _currentSpeed;
        #endregion

        #region UnityMethods
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                _onGround = true;
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                _onGround = false;
        }
        #endregion

        public void Move(float moveHorizontal, float moveVertical, bool isRunning)
        {
            _currentSpeed = isRunning ? RunSpeed : WalkSpeed;

            _movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _currentSpeed;
            AddForce();
        }

        public void Jump()
        {
            if (_onGround)
            {
                _movement = Vector3.up * JumpForce;
                AddForce();
            }
        }

        private void AddForce()
        {
            _rigidBody.AddRelativeForce(_movement);
        }
    }
}
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpHeight;

    private Rigidbody _rigidBody;
    private Vector3 _vectorMove;
    private bool _onGround;
    private float _verticalAxis;
    private float _horizontalAxis;

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

    public void Walk(float verticalAxis, float horizontalAxis)
    {
        _verticalAxis = verticalAxis; _horizontalAxis = horizontalAxis;
        Move(WalkSpeed);
    }
    public void Run(float verticalAxis, float horizontalAxis)
    {
        _verticalAxis = verticalAxis; _horizontalAxis = horizontalAxis;
        Move(RunSpeed);
    }
    public void Jump()
    {
        if (_onGround)
            _rigidBody.AddRelativeForce(Vector3.up * JumpHeight);
    }
    private void Move(float speed)
    {
        _vectorMove = new Vector3(_verticalAxis * speed, _rigidBody.velocity.y, _horizontalAxis * speed);
        _rigidBody.AddRelativeForce(_vectorMove, ForceMode.Acceleration);
    }
}

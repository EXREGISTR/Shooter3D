using UnityEngine;

public class InputController : MonoBehaviour
{
    #region AxisNames
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";
    #endregion

    [SerializeField] private PlayerMovement Player;

    private void Update()
    {
        Walk();

        if (Input.GetKey(KeyCode.Space))
            Jump();

        if (Input.GetKey(KeyCode.LeftShift))
            Run();
    }
    private void Walk()
    {
        Player.Walk(Input.GetAxis(Vertical), Input.GetAxis(Horizontal));
    }
    private void Run()
    {
        Player.Run(Input.GetAxis(Vertical), Input.GetAxis(Horizontal));
    }
    private void Jump()
    {
        Player.Jump();
    }
}
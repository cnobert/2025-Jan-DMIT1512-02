using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed, jumpForce, moveForce;//5, 100, 200

    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;

    private InputAction _jump, _move;

    void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalMovement = _move.ReadValue<Vector2>().x;

        //Have we reached _maxSpeed? If not, add force.
        if(horizontalMovement * _myRigidBody.linearVelocityX < maxSpeed)
        {
            _myRigidBody.AddForce(Vector2.right * horizontalMovement * moveForce);
        }
        //clamp to max speed
        //Mathf.Sign returns -1 or 1, and allows us to keep the direction in world space
        if(Mathf.Abs(_myRigidBody.linearVelocityX) > maxSpeed)
        {
            _myRigidBody.linearVelocityX = Mathf.Sign(_myRigidBody.linearVelocityX) * maxSpeed;
        }
    }
}

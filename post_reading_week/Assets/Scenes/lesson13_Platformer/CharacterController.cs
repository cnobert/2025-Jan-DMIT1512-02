using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed, jumpForce, moveForce;//5, 100, 200
    public Transform groundCheck;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private InputAction _jump, _move;
    private bool _grounded, _jumpInitiated;

    void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _jump = InputSystem.actions.FindAction("Jump");
        _move = InputSystem.actions.FindAction("Move");
        _jumpInitiated = false;
    }

    void Update()
    {
        //_grounded will be true if the line passes through an object set to have the layer "Ground"
        _grounded = 
            Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(_jump.WasPressedThisFrame() && _grounded)
        {
            _jumpInitiated = true;
        }    
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
        if(_jumpInitiated)
        {
            _myRigidBody.AddForce(new Vector2(0, jumpForce));
            _myAnimator.SetTrigger("Jump");
            _jumpInitiated = false;
        }
    }
}

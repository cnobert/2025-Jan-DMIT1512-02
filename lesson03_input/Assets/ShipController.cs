using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private InputAction _moveAction, _spinAction;

    public float movementSpeed;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _spinAction = InputSystem.actions.FindAction("Spin");
    }

    void Update()
    {
        #region movement
        // give the game object the ability to move: 
        //left, right, up and down 
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        moveValue *= movementSpeed * Time.deltaTime;
        transform.Translate(moveValue);
        #endregion
        //give the player the ability to spin the object in either direction by pressing “j” or “k”
        float spinDirection = _spinAction.ReadValue<float>();
        Debug.Log(spinDirection); 
    }
}

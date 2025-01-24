using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private InputAction _moveAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // give the game object the ability to move: 
        //left, right, up and down 
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        
        Debug.Log(moveValue);
    }
}

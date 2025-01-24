using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private InputAction _moveAction, _spinAction, _scaleAction;

    public float movementSpeed, spinSpeed, scaleSpeed;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _spinAction = InputSystem.actions.FindAction("Spin");
        _scaleAction = InputSystem.actions.FindAction("Scale");
    }

    void Update()
    {
        #region movement
        // give the game object the ability to move: 
        //left, right, up and down 
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        moveValue *= movementSpeed * Time.deltaTime;
        transform.Translate(moveValue, Space.World);
        #endregion
        #region rotation
        //give the player the ability to spin the object in either direction by pressing “j” or “k”
        float spinValue = _spinAction.ReadValue<float>();
        spinValue *= spinSpeed * Time.deltaTime;
        transform.Rotate(0, 0, spinValue);
        #endregion
        #region scaling
        //give the player the ability to grow and shrink the game object by pressing “u” or “i”
        //step 01 - create the input action in the Unity Editor
        //step 02 - write the code that does the scaling
        float scaleValue = _scaleAction.ReadValue<float>();
        scaleValue *= scaleSpeed * Time.deltaTime;
        Vector3 scaleChange = new Vector3(scaleValue, scaleValue, scaleValue);
        transform.localScale += scaleChange;
        #endregion
    }
}

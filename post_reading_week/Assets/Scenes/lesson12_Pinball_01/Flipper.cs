using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    private HingeJoint2D _joint2D;
    private InputAction _flipRight;
    private InputAction _flipLeft;
    
    public enum FlipperType { Right, Left}
    public FlipperType _flipperType;

    void Start()
    {
        _joint2D = GetComponent<HingeJoint2D>();
        _flipRight = InputSystem.actions.FindAction("FlipperRight");
        _flipLeft = InputSystem.actions.FindAction("FlipperLeft");
    }
    void Update()
    {
        switch(_flipperType)
        {
            case FlipperType.Right:
                _joint2D.useMotor = _flipRight.IsPressed();
                break;
            case FlipperType.Left:
                _joint2D.useMotor = _flipLeft.IsPressed();
                break;
        }
        
    }
}

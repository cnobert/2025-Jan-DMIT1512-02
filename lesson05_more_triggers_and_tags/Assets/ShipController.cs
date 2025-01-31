using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float movementSpeed;
    private InputAction _moveAction;

    private bool _maxLeftReached = false, _maxRightReached = false;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        //Exercise:
        //leveraging your new knowledge about Triggers
        //Make the ship stop when it touches WallLeft. It should be able to move away, to the
        //right, after it has stopped


        Vector2 translationValue = _moveAction.ReadValue<Vector2>();
        translationValue.y = 0;
        translationValue *= Time.deltaTime * movementSpeed;

        //is the movement towards the left?
        //did they reach the maximum distance they can move to the left?
        if(translationValue.x < 0 && !_maxLeftReached)
        {
            transform.Translate(translationValue);
        }

        if(translationValue.x > 0 && !_maxRightReached)
        {
            transform.Translate(translationValue);
        }

        
    }
    /*
        There are three methods that deal with trigger collisions:
        OnTriggerEnter2D - called when the objects first come into contact
        OnTriggerStay2D - called every frame during which they are in contact
        OnTriggerExit2D - called when they stop being in contact
    */


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //is whatever I bumped into to the my left?
        //if(collider2D.transform.position.x < transform.position.x)
        if(collider2D.CompareTag("WallLeft"))
        {
            _maxLeftReached = true;
        }
        if(collider2D.CompareTag("WallRight")) //it's to my right
        {
            _maxRightReached = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("WallLeft"))
        {
            _maxLeftReached = false;
        }
        if(collider2D.CompareTag("WallRight")) //it's to my right
        {
            _maxRightReached = false;
        }
    }
    
    
    // void OnTriggerStay2D(Collider2D collider2D)
    // {
    //     //Debug.Log("#################OnTriggerStay2D#################");
    // }
}

using UnityEngine;
using UnityEngine.Animations;


public class SquareController : MonoBehaviour
{
    public float speedX, directionX;
    public float speedY, directionY;
    public float rotationSpeedZ, rotationDirectionZ;

    public Vector3 scaleChangeDirection, scaleChangeMax, scaleChangeMin;
    public float scaleChangeSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        //"this" refers to the object that we're coding in
        //"Translate" is a method of the "Transform" class
        //this.gameObject.transform.Translate(new Vector2(0.01f, 0));

        //due to lag, it could be more than one frame until Update is called
        //so, we multiply the movement amounts by the amount of time that 
        //has passed since the last call to update
        Vector2 movementAmount = new Vector2(speedX * directionX, speedY * directionY)  * Time.deltaTime;

        //"transform" is the transform of the game object to which this script is attached
        transform.Translate(movementAmount, Space.World);

        //the following code block from ChatGPT
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        float left = bottomLeft.x;
        float right = topRight.x;
        float top = topRight.y;
        float bottom = bottomLeft.y;
        //Debug.Log(GetComponent<Renderer>());
        //TODO: the game object is bouncing half of its width too late, figure out how to fix
        
        //in script, we can access any component of the game object to which
        //the script is attached
        //for example:
        //this.gameObject.GetComponent<Renderer>();
        //shortcut: GetComponent<Renderer>()
        //AND another example:
        //this.gameObject.GetComponent<Transform>();
        //shortcut: transform

        float width = transform.localScale.x;//or or GetComponent<Renderer>().bounds.size.x;
        float height = transform.localScale.y;//GetComponent<Renderer>().bounds.size.y;

        if(transform.position.x + (width / 2) >= right || transform.position.x - (width / 2) <= left)
        {
            directionX *= -1;
        }

        if(transform.position.y + (height / 2) >= top || transform.position.y - (height / 2) <= bottom)
        {
            directionY *= -1;
        }
        //Debug.Log(Time.deltaTime); TODO: look into why Time.deltaTime is 0.0009 every call to update
        
        //we it 3 "Euler" values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);

        //2025-01-22 EXERCISE:
        //make the game object just sit in the middle of the screen and grow
        // Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        // transform.localScale += scaleChange;

        //2025-01-22 EXERCISE:  
        //alter the above code so that the game object grows and shrinks, 
        //then grows and shrinks again
        Vector3 scaleChange = (scaleChangeDirection * scaleChangeSpeed) * Time.deltaTime;
        transform.localScale += scaleChange;
        if(transform.localScale.x > scaleChangeMax.x || transform.localScale.x < scaleChangeMin.x)
        {
            scaleChangeDirection.x *= -1;
        }
        if(transform.localScale.y > scaleChangeMax.y || transform.localScale.y < scaleChangeMin.y)
        {
            scaleChangeDirection.y *= -1;
        }
    }
}

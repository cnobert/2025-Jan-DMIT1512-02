using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speedX, directionX;
    public float speedY, directionY;
    public float rotationSpeedZ, rotationDirectionZ;

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
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));
        float left = bottomLeft.x;
        float right = topRight.x;
        float top = topRight.y;
        float bottom = bottomLeft.y;

        if(transform.position.x >= 7.33 || transform.position.x <= -7.33)
        {
            directionX *= -1;
        }
        //Debug.Log(Time.deltaTime); TODO: look into why Time.deltaTime is 0.0009 every call to update
        
        //we it 3 "Euler" values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);
    }
}

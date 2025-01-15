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

        transform.Translate(movementAmount, Space.World);
        
        //we it 3 "Euler" values (0-360)
        transform.Rotate(0, 0, rotationSpeedZ * rotationDirectionZ * Time.deltaTime);
    }
}

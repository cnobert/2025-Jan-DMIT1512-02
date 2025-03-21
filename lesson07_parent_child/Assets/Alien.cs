using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject explosionPrefab;  // Assign in Inspector
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("WallLeft")
            || collider2D.gameObject.CompareTag("WallRight"))
        {
            //change the direction of the game object that is my direct parent
            //GetComponent<Parent>() returns the object of the class Parent.cs
            transform.parent.GetComponent<Parent>().direction.x *= -1;
            //todo: move the squadron down by some amount

            Instantiate(explosionPrefab); 
            Destroy(collider2D.gameObject);  // Destroy enemy 
        }
    }
}

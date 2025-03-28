using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D theRBThatHitMe = collision.gameObject.GetComponent<Rigidbody2D>();
        theRBThatHitMe.AddForce(force * collision.relativeVelocity);
    }
}

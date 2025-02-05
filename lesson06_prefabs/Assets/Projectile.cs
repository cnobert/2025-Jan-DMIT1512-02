using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public Vector2 direction;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(collider2D.gameObject);
        }
    }
}

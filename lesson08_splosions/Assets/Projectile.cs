using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public Vector2 direction;

    public GameObject splosionPrefab;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))

        {
            Instantiate(splosionPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(collider2D.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public Vector2 direction;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }
}

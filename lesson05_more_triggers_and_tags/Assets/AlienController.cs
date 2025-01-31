using UnityEngine;

public class AlienController : MonoBehaviour
{
    public float speed;
    private Vector2 _direction  = new Vector2(1, 0);

    void Update()
    {
  
        Vector2 translationValue = _direction * Time.deltaTime * speed;
        transform.Translate(translationValue);
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("WallLeft") || 
            collider2D.gameObject.CompareTag("WallRight"))
        {
            _direction *= -1;
        }
    }
}

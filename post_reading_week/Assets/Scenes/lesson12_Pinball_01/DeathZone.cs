using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform spawnPointTransform;
    public GameObject ballPrefab;
    void Start()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnPointTransform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnPointTransform.position;
    }
}

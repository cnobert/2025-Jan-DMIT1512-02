using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private GameState _gameState;
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _gameState.Score++;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //TODO: change a label in this scene to "Game Over", then wait 5 seconds, then do the below
        SceneManager.LoadScene("StartScene");
    }
}

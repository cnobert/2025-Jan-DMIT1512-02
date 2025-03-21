using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Pinball_UI : MonoBehaviour
{
    private GameState _gameState;
    private Label _scoreLabel;
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        _scoreLabel = GetComponent<UIDocument>().rootVisualElement.Q<Label>("ScoreLabel");
    }
    void Update()
    {
        _scoreLabel.text = $"{_gameState.Score}";
    }
}

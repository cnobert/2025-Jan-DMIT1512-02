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
        _scoreLabel.text = $"{_gameState.Score}";
    }
    void Update()
    {
        if(int.Parse(_scoreLabel.text) != _gameState.Score)
        {
            _scoreLabel.text = $"{_gameState.Score}";
        }
    }
}

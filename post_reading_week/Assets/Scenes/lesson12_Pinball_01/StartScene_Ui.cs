using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartScene_Ui : MonoBehaviour
{
    private GameState _gameState;
    private Label _scoreLabel;
    void Start()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

        VisualElement _root = GetComponent<UIDocument>().rootVisualElement;
        
        _root.Q<Button>("LoadLevel01Button").clicked += LoadLevel01;
        _scoreLabel = _root.Q<Label>("ScoreLabel");
        PopulateScores();
    }
    private void PopulateScores()
    {
        _scoreLabel.text = $"{_gameState.Score}";
    }
    private void LoadLevel01()
    {
        SceneManager.LoadScene("pinball");
    }
}

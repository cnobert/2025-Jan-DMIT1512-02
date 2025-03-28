using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene01_UIComponentHandler : MonoBehaviour
{
    private Label _scoreLabel;
    private Button _increaseScoreButton;

    //in any script that needs to read/write game state data, do this:
    //Step #1, declare a gameState data member
    private GameState _gameState;

    //Step #2 (the last step)
    //declare an Awake method that looks like this:
    void Awake()
    {
        _gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _scoreLabel = root.Q<Label>("ScoreLabel");
        _scoreLabel.text = _gameState.Score + "";

        _increaseScoreButton = root.Q<Button>("IncreaseScoreButton");
        _increaseScoreButton.clicked += IncreaseScore;

        root.Q<Button>("LoadScene02Button").clicked += LoadScene02;

    }
    private void IncreaseScore()
    {
        _gameState.Score++;
        _scoreLabel.text = _gameState.Score.ToString();
    }
    private void LoadScene02()
    {
        SceneManager.LoadScene("Scene02");
    }
}

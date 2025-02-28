using UnityEngine;
using UnityEngine.UIElements;

public class Scene02_UIComponentHandler : MonoBehaviour
{
    private Label _scoreLabel;
    private Button _decreaseScoreButton;

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

        _decreaseScoreButton = root.Q<Button>("DecreaseScoreButton");
        _decreaseScoreButton.clicked += DecreaseScore;

        root.Q<Button>("LoadScene01Button").clicked += LoadScene01Button;

    }
    private void DecreaseScore()
    {
        _gameState.Score--;
        _scoreLabel.text = _gameState.Score.ToString();
    }

    private void LoadScene01Button()
    {
        SceneManager.LoadScene("Scene01");
    }
}

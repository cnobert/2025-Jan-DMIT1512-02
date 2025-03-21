using System;
using UnityEngine;

//BE CAREFUL
//This script must be a component of a game object that is tagged with "GameState"
//in the OPENING scene of the game

[Serializable]
public class GameData
{
    public int _score = 0;
    public int _highScore = 0;
}
public class GameState : MonoBehaviour
{
    private GameData _gameData;
    public int Score { get => _gameData._score; set => _gameData._score = value; }

    void Awake()
    {
        _gameData = new GameData();
        GameObject [] objs = GameObject.FindGameObjectsWithTag("GameState");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

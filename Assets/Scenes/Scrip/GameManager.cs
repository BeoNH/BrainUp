using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get => instance; }

    public GameState state;

    public static event Action<GameState> OnStateChange;

    protected void Awake()
    {
        if (GameManager.instance != null) Debug.LogError("Only 1 gameManager guy =.= ");
        GameManager.instance = this;    
    }

    protected void Start()
    {
        UpdateGameState(GameState.StartGame);
    }

    public void UpdateGameState(GameState newState)
    {
        this.state = newState;

        switch(newState)
        {
            case GameState.StartGame:
                HandleStart();
                break;
            case GameState.Playing:
                HandlePlay();
                break;
            case GameState.NextLevel:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnStateChange?.Invoke(newState);
    }

    private void HandlePlay()
    {
        Debug.Log("choi game neeeeeeeeeeeeeeee");
    }

    private void HandleStart()
    {
        Debug.Log("cbi choi game");
    }
}

public enum GameState
{
    StartGame,
    Playing,
    NextLevel,
    Win,
    Lose
}

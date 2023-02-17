using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get => instance; }

    public GameState state;

    public static event Action<GameState> OnStateChange;

    private int CountHit = 0;

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
        if(Input.GetMouseButtonDown(0))
        {
            GameObject clickedObject = GetClickedObject();

            // loi click chua chon dung object theo th? t?
            if (clickedObject != null && Spawner.Instance.Health == CountHit) 
            {
                CountHit++;

                if (CountHit == (Spawner.Instance.CountPrefab))
                {
                    Debug.Log("You win!");
                    ResetGame();
                }
            }
            else
            {
                Debug.Log("Wrong click. Starting over.");
                ResetGame();
            }
        }    
        //Debug.Log("choi game neeeeeeeeeeeeeeee");
    }

    private void HandleStart()
    {
        Debug.Log("cbi choi game");
    }

    private GameObject GetClickedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    protected void ResetGame()
    {
        CountHit = 0;
        Spawner.Instance.CountPrefab = 5;
        //Destroy het ca prefab da spwan.    
        state = GameState.StartGame;
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

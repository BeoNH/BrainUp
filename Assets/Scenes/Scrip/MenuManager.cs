using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMenu;
    private void Awake()
    {
        GameManager.OnStateChange += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= GameManagerOnGameStateChanged;

    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        GameMenu.SetActive(state == GameState.StartGame);
    }

    public void startGame()
    {
        GameMenu.SetActive(false);
        Spawner.Instance.callSpaw();       
    }
}

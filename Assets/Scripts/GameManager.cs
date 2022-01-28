using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PauseMenu pauseMenu;

    private GameStates gameState;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        gameState = GameStates.InGame;

    }

    private void Update()
    {
        //User input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == GameStates.InGame)
            {
                PauseMenu.instance.OpenPauseMenu();
            }
            else if (gameState == GameStates.PauseMenu)
            {
                PauseMenu.instance.ClosePauseMenu();
            }
        }
        
    }

    public void StartGame()
    {
        gameState = GameStates.InGame;
    }

    public void SetGameState(GameStates gameState)
    {
        switch (gameState)
        {
            case GameStates.InGame:

                break;
            case GameStates.PauseMenu:

                break;
            case GameStates.MainMenu:

                break;
        }

        this.gameState = gameState;

    }






}



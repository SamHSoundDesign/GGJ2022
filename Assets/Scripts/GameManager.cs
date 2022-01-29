using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private LevelEnd levelEnd;

    private GameStates gameState;
    public int currentScore;
    public GameObject inGameUI;

    private LevelData levelData;
    public PlayGrid playGrid;
    public UserInput userInput;
    public GridController gridController;
    private int targetScore;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        pauseMenu = PauseMenu.instance;
        levelEnd = LevelEnd.instance;
        levelEnd.gameObject.SetActive(false);

        gameState = GameStates.InGame;
        levelData = GetComponent<LevelData>();
        userInput = GetComponent<UserInput>();
        SetupLevel();

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

        if(gameState == GameStates.InGame)
        {
            userInput.Updates();
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

    public void UpdateScore(int score)
    {
        currentScore += score;

        if(currentScore >= targetScore)
        {
            LevelWon();
        }

        inGameUI.GetComponent<TextMeshProUGUI>().text = this.currentScore.ToString();
    }

    private void LevelWon()
    {
        gameState = GameStates.LevelComplete;
        levelEnd.OpenMenu();
    }

    public void LevelLost()
    {

    }

    public void SetupLevel()
    {
        Board[] boardArray = FindObjectsOfType<Board>();

        Board boardA = null;
        Board boardB = null;

        for (int i = 0; i < boardArray.Length; i++)
        {
            if(boardArray[i].isBoardA == true)
            {
                boardA = boardArray[i];
            }

            if (boardArray[i].isBoardA == false)
            {
                boardB = boardArray[i];
            }

        }

        LevelSO levelSO = levelData.GetLevelSO();

        targetScore = levelSO.targetScore;

        boardA.SetBoardPosition(new Vector3(-levelSO.gridWidth , 0, 0));
        boardB.SetBoardPosition(new Vector3(levelSO.gridWidth , 0, 0));

        playGrid.gridHeight = levelSO.failHeight;
        playGrid.gridWidth = levelSO.gridWidth;

        userInput.pauseBetweenDrops = levelSO.levelSpeed * 3 / 10;
        userInput.UpdateNextDropTime();

        gridController.Setup(boardA , boardB , levelSO.clues , playGrid);

        StartLevel();

    }

    private void StartLevel()
    {
        gameState = GameStates.InGame;
        userInput.UpdateNextDropTime();
    }
}



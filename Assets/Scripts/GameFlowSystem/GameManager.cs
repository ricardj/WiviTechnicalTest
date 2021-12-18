using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LandingGUI landingGUI;
    public GameplayGUI gameplayGUI;
    public EndGameGUI gameOverPanelController;


    [Header("Managers")]
    public PlayerManager playerManager;
    public EnemiesManager enemiesManager;


    [Header("Broadcasts on")]
    public EmptyEventSO onGameStarted;


    bool isGameStarted = false;
    bool isGameFinished = false;

    // Update is called once per frame
    void Update()
    {
        CheatControls();
        StartInput();
        GameEndInput();
    }

    private void GameEndInput()
    {
        if (isGameFinished)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ReloadGameplayScene();
            }
        }
    }

    private void StartInput()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isGameStarted = true;
                StartGame();
            }
        }
    }

    private static void CheatControls()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadGameplayScene();
            }
        }
    }

    private static void ReloadGameplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        landingGUI.HideLanding();
        onGameStarted.RaiseEmptyEvent();
        gameplayGUI.ShowLowerPanelAndActivate();
        enemiesManager.ActivateEnemies();
        playerManager.ActivateControl();
        playerManager.OnPlayerCharacterDie.AddListener(() =>
        {
            EndGame(false);
        });
        enemiesManager.OnAllEnemiesDeath.AddListener(() =>
        {
            EndGame(true);

        });
    }

    internal void EndGame(bool isWin)
    {
        playerManager.DeactivateControl();
        gameplayGUI.DeactivateLowerPanel();

        if (isWin)
        {
            gameOverPanelController.ShowEndGameWin();
        }
        else
        {
            gameOverPanelController.ShowEndGame();

        }
        isGameFinished = true;
    }

}

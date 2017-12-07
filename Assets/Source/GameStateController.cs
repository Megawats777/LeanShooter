﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{

    /*--Ui references--*/
    GameplayUi gameplayUiRef;
    GameOverUi gameOverUiRef;

    /*--External references--*/
    PlayerCharacter player;
    Clock clock;
    TargetManager targetManager;
    ScoreGoalManager scoreGoalManager;

    // Called before start
    private void Awake()
    {
        gameplayUiRef = FindObjectOfType<GameplayUi>();
        gameOverUiRef = FindObjectOfType<GameOverUi>();

        player = FindObjectOfType<PlayerCharacter>();
        clock = FindObjectOfType<Clock>();
        targetManager = FindObjectOfType<TargetManager>();
        scoreGoalManager = FindObjectOfType<ScoreGoalManager>();
    }

    // Use for initialization
    private void Start()
    {
        startGame();
    }


    // Start the game
    public void startGame()
    {
        player.isInputEnabled = true;

        scoreGoalManager.setScoreGoal();
        clock.startClock();
        gameplayUiRef.showUi();
        targetManager.selectTargetToEnable();
    }

    // Restart the game
    public void restartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    // End the game
    public void endGame(bool playerMadeMistake)
    {
        player.isInputEnabled = false;
        clock.stopClock();

        
        if (playerMadeMistake == false)
        {
            // If the player has a equal or higher score than the goal
            if (player.getScore() >= scoreGoalManager.scoreGoal)
            {
                // Set the title of the game over ui to be "Goal Achieved"
                gameOverUiRef.title.text = "Goal Achieved";
                WinStreakManager.increaseWinStreak();
            }

            // Otherwise set the title of the game over ui to be "Goal Failed"
            else
            {
                gameOverUiRef.title.text = "Goal Failed";
                WinStreakManager.resetWinStreak();
            }
        }

        else
        {
            gameOverUiRef.title.text = "Goal Failed";
            WinStreakManager.resetWinStreak();
        }

        gameOverUiRef.playerScoreText.text = player.getScore().ToString();
        gameOverUiRef.scoreGoalText.text = scoreGoalManager.scoreGoal.ToString();
    
        // Set visibility of ui elements
        gameplayUiRef.hideUi();
        gameOverUiRef.showUi();

    }
}
using System;
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

    private void Awake()
    {
        gameplayUiRef = FindObjectOfType<GameplayUi>();
        gameOverUiRef = FindObjectOfType<GameOverUi>();

        player = FindObjectOfType<PlayerCharacter>();
        clock = FindObjectOfType<Clock>();
        targetManager = FindObjectOfType<TargetManager>();
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
    public void endGame()
    {
        player.isInputEnabled = false;
        clock.stopClock();

        // Set visibility of ui elements
        gameplayUiRef.hideUi();
        gameOverUiRef.showUi();
    }
}
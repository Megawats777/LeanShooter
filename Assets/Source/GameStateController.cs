using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{

    /*--Ui references--*/
    GameplayUi gameplayUiRef;
    GameOverUi gameOverUiRef;

    /*--External references--*/
    PlayerCharacter player;
    Clock clock;

    private void Awake()
    {
        gameplayUiRef = FindObjectOfType<GameplayUi>();
        gameOverUiRef = FindObjectOfType<GameOverUi>();

        player = FindObjectOfType<PlayerCharacter>();
        clock = FindObjectOfType<Clock>();
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
    }

    // Pause the game
    public void pauseGame()
    {

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
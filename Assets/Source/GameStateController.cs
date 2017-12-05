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
        // Set the player's desired location to be it's starting point
        player.position = player.startingPos;

        // Disable all targets
        foreach (Target target in targetManager.targetList)
        {
            target.disableTarget();
        }

        clock.currentTime = clock.startingTime;
        clock.updateClockTextDisplay();

        // Hide the game over ui
        gameOverUiRef.hideUi();

        // After a delay start the game again
        Invoke("startGame", 2.0f);
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
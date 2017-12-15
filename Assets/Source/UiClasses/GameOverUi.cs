using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUi : UiBase
{
    

    /*--Ui element references--*/
    public Button restartButton;
    public Button quitButton;
    public Text title;
    public Text playerScoreText;
    public Text scoreGoalText;
    public Text winStreakText;

    /*--External References--*/
    PlayerCharacter player;
    GameStateController gameStateController;
    ScoreGoalManager scoreGoalManager;

    // Called before start
    private void Awake()
    {
        base.Awake();
        player = FindObjectOfType<PlayerCharacter>();
        gameStateController = FindObjectOfType<GameStateController>();
        scoreGoalManager = FindObjectOfType<ScoreGoalManager>();
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
        hideUi();

        restartButton.onClick.AddListener(delegate
        {
            gameStateController.restartGame();
        });

        quitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

    public override void showUi()
    {
        base.showUi();
        winStreakText.text = WinStreakManager.getWinStreak().ToString();
        scoreGoalText.text = scoreGoalManager.scoreGoal.ToString();
        playerScoreText.text = player.getScore().ToString();

        // If the player won
        if (player.isWinner == true)
        {
            // Set the title text to be "you win"
            title.text = "You Win";
        }

        // Otherwise
        else
        {
            // Set the title text to be "you lose"
            title.text = "You Lose";
        }
    }


}

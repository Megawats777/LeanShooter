using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUi : UiBase
{
    // Ui element refernces
    public Text scoreText;
    public Text timeText;
    public Text scoreGoalText;
    public Text winStreakText;

    // External references
    PlayerCharacter player;
    Clock clock;
    ScoreGoalManager scoreGoalManager;

    // Called before start
    void Awake()
    {
        base.Awake();
        player = FindObjectOfType<PlayerCharacter>();
        clock = FindObjectOfType<Clock>();
        scoreGoalManager = FindObjectOfType<ScoreGoalManager>();
    }


    private void Start()
    {
        base.Start();
        setUiContent();
    }

    // A function called every frame
    void Update()
    {
        setUiContent();
    }

    // Set the content of the ui
    private void setUiContent()
    {
        scoreText.text = player.getScore().ToString();
        scoreGoalText.text = scoreGoalManager.scoreGoal.ToString();
        timeText.text = clock.currentTime.ToString();
        winStreakText.text = WinStreakManager.getWinStreak().ToString();
    }

}

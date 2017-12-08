using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGoalManager : MonoBehaviour
{
    // Variables
    public int minScoreGoal = 2;
    public int maxScoreGoal = 16;
    [HideInInspector]
    public int scoreGoal = 0;


    // Called before start
    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the score goal
    public void setScoreGoal()
    {
        for (int i = 0; i < WinStreakManager.getWinStreak(); i++)
        {
            minScoreGoal += Random.Range(4, 5);
            maxScoreGoal += Random.Range(4, 5);
        }

        print("Min Score Goal: " + minScoreGoal);
        print("Max Score Goal: " + maxScoreGoal);

        scoreGoal = Random.Range(minScoreGoal, maxScoreGoal);
    }
}

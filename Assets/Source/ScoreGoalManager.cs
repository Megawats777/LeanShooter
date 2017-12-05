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

    // Ui References
    private Text goalText;

    // Called before start
    private void Awake()
    {
        goalText = GameObject.FindGameObjectWithTag("GoalText").GetComponent<Text>();   
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
        scoreGoal = Random.Range(minScoreGoal, maxScoreGoal);
        goalText.text = scoreGoal.ToString();
    }
}

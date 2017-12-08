using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    /*--Time Properties--*/
    public int startingTime = 60;
    [HideInInspector]
    public int currentTime = 0;


    /*--External references--*/
    GameStateController gameStateController;

    // Called before start
    private void Awake()
    {
        gameStateController = FindObjectOfType<GameStateController>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start clock
    public void startClock()
    {
        InvokeRepeating("runClock", 1.0f, 1.0f);
    }


    // Stop clock
    public void stopClock()
    {
        CancelInvoke("runClock");
    }


    // Run clock
    private void runClock()
    {
        currentTime--;

        // If the current time is 0
        // End the game
        if (currentTime == 0)
        {
            stopClock();
            gameStateController.endGame(false);
            print("Game ended");
        }
    }

    // Update clock text display
    public void updateClockTextDisplay()
    {

    }
}

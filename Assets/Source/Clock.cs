using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    /*--Time Properties--*/
    public int startingTime = 60;
    private int currentTime = 0;


    /*--UI Element references--*/
    private Text clockText;


    // Called before start
    private void Awake()
    {
        clockText = GameObject.FindGameObjectWithTag("ClockText").GetComponent<Text>();
    }


    // Use this for initialization
    void Start()
    {
        currentTime = startingTime;
        clockText.text = currentTime.ToString();
        startClock();
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
        clockText.text = currentTime.ToString();

        // If the current time is 0
        // End the game
        if (currentTime == 0)
        {
            stopClock();
            print("Game ended");
        }
    }
}

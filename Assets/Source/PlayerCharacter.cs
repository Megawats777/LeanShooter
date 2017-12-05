using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    // Is input enabled
    public bool isInputEnabled = false;

    /*--Score system properties--*/

    private int score = 0;
    private Text scoreText;

    /*--Lean movement properties--*/


    // Can the player lean
    [Header("Lean movement properties")]
    public bool canLean = true;

    // Lean enable delay
    public float enableLeanDelay = 0.15f;

    // Lean animation speed
    public float leanAnimSpeed = 10.0f;

    // Lean position status variables
    public bool isLeaningUp = false;
    public bool isLeaningLeft = false;
    public bool isLeaningRight = false;


    // Lean nav point references
    public LeanNavPoint topLeanNavPoint;
    public LeanNavPoint leftLeanNavPoint;
    public LeanNavPoint rightLeanNavPoint;


    /*--Lean movement properties end--*/


    // Can the player fire
    public bool canFire = false;
    public bool targetHit = false;

    // Player status variables
    public Vector3 startingPos;
    public Vector3 position;

    [HideInInspector]
    public bool wasGameRestarted = false;

    // External references
    private TargetManager targetManager;
    private GameStateController gameStateController;

    // Called before start
    private void Awake()
    {
        targetManager = FindObjectOfType<TargetManager>();
        gameStateController = FindObjectOfType<GameStateController>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        setScore(0);
        startingPos = transform.position;
        position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (isInputEnabled == true)
        {
            // Control lean actions
            controlLeanActions();

            // Control firing action
            controlFiringAction();
        }


        // Always blend to the player's position
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * leanAnimSpeed);
    }

    // Control Lean actions
    private void controlLeanActions()
    {
        controlLeaningUp();
        controlLeaningLeft();
        controlLeaningRight();
    }

    // Control leaning up
    private void controlLeaningUp()
    {
        // If the player presses the lean up button
        if (Input.GetButtonDown("LeanUp") && canLean == true)
        {
            // If the player is not leaning up, left, and right
            // Lean up
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Check if the player leaned in the wrong direction
                checkIfPlayerLeanedInWrongDirection(LanePositions.Middle);

                canFire = true;
                isLeaningUp = true;
                position.y = topLeanNavPoint.transform.position.y;
            }
        }

        // If the player is leaning up
        if (isLeaningUp == true)
        {
            // If the player releases the lean up button
            // Stop leaning up
            if (Input.GetButtonUp("LeanUp"))
            {
                canFire = false;
                isLeaningUp = false;
                position = startingPos;

                // Perform a check on if a new target should be enabled
                targetManager.performNewEnabledTargetCheck();

                if (wasGameRestarted == false)
                {
                    canLean = false;
                    Invoke("allowPlayerToLean", enableLeanDelay);
                }

                else
                {
                    wasGameRestarted = false;
                }
            }
        }
    }

    // Control leaning left
    private void controlLeaningLeft()
    {
        // If the player presses the lean left button
        if (Input.GetButtonDown("LeanLeft") && canLean == true)
        {
            // If the player is not leaning up, left, and right
            // Lean left
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Check if the player leaned in the wrong direction
                checkIfPlayerLeanedInWrongDirection(LanePositions.Left);


                canFire = true;
                isLeaningLeft = true;
                position.x = leftLeanNavPoint.transform.position.x;
            }
        }

        // If the player is leaning left
        if (isLeaningLeft == true)
        {
            // If the player releases the lean left button
            // Stop leaning left
            if (Input.GetButtonUp("LeanLeft"))
            {
                canFire = false;
                isLeaningLeft = false;
                position = startingPos;


                // Perform a check on if a new target should be enabled
                targetManager.performNewEnabledTargetCheck();

                if (wasGameRestarted == false)
                {
                    canLean = false;
                    Invoke("allowPlayerToLean", enableLeanDelay);
                }

                else
                {
                    wasGameRestarted = false;
                }
            }
        }
    }

    // Control leaning right
    private void controlLeaningRight()
    {
        // If the player presses the lean right button
        if (Input.GetButtonDown("LeanRight") && canLean == true)
        {
            // If the player is not leaning up, left, and right
            // Lean right
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Check if the player leaned in the wrong direction
                checkIfPlayerLeanedInWrongDirection(LanePositions.Right);


                canFire = true;
                isLeaningRight = true;
                position.x = rightLeanNavPoint.transform.position.x;
            }
        }

        // If the player is leaning right
        if (isLeaningRight == true)
        {
            // If the player releases the lean right button
            // Stop leaning right
            if (Input.GetButtonUp("LeanRight"))
            {
                canFire = false;
                isLeaningRight = false;
                position = startingPos;


                // Perform a check on if a new target should be enabled
                targetManager.performNewEnabledTargetCheck();

                if (wasGameRestarted == false)
                {
                    canLean = false;
                    Invoke("allowPlayerToLean", enableLeanDelay);
                }

                else
                {
                    wasGameRestarted = false;
                }
            }
        }
    }

    // Check if the player leaned in the wrong direction
    private void checkIfPlayerLeanedInWrongDirection(LanePositions laneToCheck)
    {
        // If the current target to destroy is not in the lane to check
        if (targetManager.targetToDestroy.lanePosition != laneToCheck)
        {
            print("Wrong Position!");
            gameStateController.endGame();
        }
    }

    // Allow the player to lean
    private void allowPlayerToLean()
    {
        canLean = true;
    }



    // Control firing action
    private void controlFiringAction()
    {
        // If the player presses the fire button and can fire
        if (Input.GetButtonDown("Fire") && canFire == true)
        {
            targetHit = false;
            Target designatedTarget = null;

            // Find all the targets in the level
            foreach (Target currentTarget in FindObjectsOfType<Target>())
            {

                // If one of the target's lane position is middle and the player is leaning up and the current target is enabled
                if (currentTarget.lanePosition == LanePositions.Middle && isLeaningUp == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Set the designated target
                    designatedTarget = currentTarget;
                }

                // If one of the target's lane position is left and the player is leaning left and the current target is enabled
                else if (currentTarget.lanePosition == LanePositions.Left && isLeaningLeft == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Set the designated target
                    designatedTarget = currentTarget;
                }

                // If one of the target's lane position is right and the player is leaning right and the current target is enabled
                else if (currentTarget.lanePosition == LanePositions.Right && isLeaningRight == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Set the designated target
                    designatedTarget = currentTarget;
                }
            }

            // If a target was not hit
            if (targetHit == false)
            {
                print("No target hit");
                gameStateController.endGame();
            }

            // If a target was hit
            else if (targetHit == true)
            {
                print("Target Hit!");

                // Damage the designated target
                designatedTarget.damageTarget();
            }
        }
    }

    // Increase the player's score
    public void increaseScore(int increaseAmount)
    {
        setScore(score + increaseAmount);
    }


    // Decrease the player's score
    public void decreaseScore(int decreaseAmount)
    {
        setScore(score - decreaseAmount);
    }

    // Set the player's score
    public void setScore(int score)
    {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

    // Get the player's score
    public int getScore()
    {
        return score;
    }
    
    // Draw debug shapes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.75f);
    }
}

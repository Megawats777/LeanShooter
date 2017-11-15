using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    /*--Lean movement properties--*/


    // Can the player lean
    public bool canLean = true;

    // Lean enable delay
    public float enableLeanDelay = 0.15f;

    // Lean animation speed
    public float leanAnimSpeed = 10.0f;

    // Lean position status variables
    private bool isLeaningUp = false;
    private bool isLeaningLeft = false;
    private bool isLeaningRight = false;


    // Lean nav point references
    public LeanNavPoint topLeanNavPoint;
    public LeanNavPoint leftLeanNavPoint;
    public LeanNavPoint rightLeanNavPoint;


    /*--Lean movement properties end--*/


    // Can the player fire
    public bool canFire = false;
    public bool targetHit = false;

    // Player status variables
    private Vector3 startingPos;
    private Vector3 position;


    // External references
    private TargetManager targetManager;


    // Called before start
    private void Awake()
    {
        targetManager = FindObjectOfType<TargetManager>();
    }

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
        position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {

        // Control lean actions
        controlLeanActions();


        // If the player presses the fire button and can fire
        if (Input.GetKeyDown(KeyCode.Space) && canFire == true)
        {
            targetHit = false;

            // Find all the targets in the level
            foreach (Target currentTarget in FindObjectsOfType<Target>())
            {

                // If one of the target's lane position is middle and the player is leaning up and the current target is enabled
                if (currentTarget.lanePosition == LanePositions.Middle && isLeaningUp == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Add to the player's score

                    // Destroy the current target
                    currentTarget.disableTarget();
                }

                // If one of the target's lane position is left and the player is leaning left and the current target is enabled
                else if (currentTarget.lanePosition == LanePositions.Left && isLeaningLeft == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Add to the player's score

                    // Destroy the current target
                    currentTarget.disableTarget();
                }

                // If one of the target's lane position is right and the player is leaning right and the current target is enabled
                else if (currentTarget.lanePosition == LanePositions.Right && isLeaningRight == true && currentTarget.isEnabled == true)
                {
                    // Mark that a target was hit
                    targetHit = true;

                    // Add to the player's score

                    // Destroy the current target
                    currentTarget.disableTarget();
                }
            }

            // If a target was not hit
            if (targetHit == false)
            {
                // Reduce the player's score
                print("No target hit");
            }

            // Do not allow the player to fire
            canFire = false;
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
                // If the current target to destroy is not in the middle lane
                // Destroy the current target
                if (targetManager.targetToDestroy.lanePosition != LanePositions.Middle)
                {
                    targetManager.targetToDestroy.disableTarget();
                }

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

                
                targetManager.selectTargetToEnable();
                canLean = false;
                Invoke("allowPlayerToLean", enableLeanDelay);
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
                // If the current target to destroy is not in the left lane
                // Destroy the current target
                if (targetManager.targetToDestroy.lanePosition != LanePositions.Left)
                {
                    targetManager.targetToDestroy.disableTarget();
                }


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


                targetManager.selectTargetToEnable();
                canLean = false;
                Invoke("allowPlayerToLean", enableLeanDelay);
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
                // If the current target to destroy is not in the right lane
                // Destroy the current target
                if (targetManager.targetToDestroy.lanePosition != LanePositions.Right)
                {
                    targetManager.targetToDestroy.disableTarget();
                }


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


                targetManager.selectTargetToEnable();
                canLean = false;
                Invoke("allowPlayerToLean", enableLeanDelay);
            }
        }
    }


    // Allow the player to lean
    private void allowPlayerToLean()
    {
        canLean = true;
    }


    // Draw debug shapes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.75f);
    }
}

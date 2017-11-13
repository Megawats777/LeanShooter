using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
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


    // Player status variables
    private Vector3 startingPos;
    private Vector3 position;

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            // If the player is not leaning up, left, and right
            // Lean up
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                isLeaningUp = true;
                position.y = topLeanNavPoint.transform.position.y;
            }
        }

        // If the player is leaning up
        if (isLeaningUp == true)
        {
            // If the player releases the lean up button
            // Stop leaning up
            if (Input.GetKeyUp(KeyCode.W))
            {
                isLeaningUp = false;
                position = startingPos;
            }
        }
    }

    // Control leaning left
    private void controlLeaningLeft()
    {
        // If the player presses the lean left button
        if (Input.GetKeyDown(KeyCode.A))
        {
            // If the player is not leaning up, left, and right
            // Lean left
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                isLeaningLeft = true;
                position.x = leftLeanNavPoint.transform.position.x;
            }
        }

        // If the player is leaning left
        if (isLeaningLeft == true)
        {
            // If the player releases the lean left button
            // Stop leaning left
            if (Input.GetKeyUp(KeyCode.A))
            {
                isLeaningLeft = false;
                position = startingPos;
            }
        }
    }

    // Control leaning right
    private void controlLeaningRight()
    {
        // If the player presses the lean right button
        if (Input.GetKeyDown(KeyCode.D))
        {
            // If the player is not leaning up, left, and right
            // Lean right
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                isLeaningRight = true;
                position.x = rightLeanNavPoint.transform.position.x;
            }
        }

        // If the player is leaning right
        if (isLeaningRight == true)
        {
            // If the player releases the lean right button
            // Stop leaning right
            if (Input.GetKeyUp(KeyCode.D))
            {
                isLeaningRight = false;
                position = startingPos;
            }
        }
    }


    // Draw debug shapes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.75f);
    }
}

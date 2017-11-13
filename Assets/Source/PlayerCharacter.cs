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
        // If the player presses the lean up button
        if (Input.GetKeyDown(KeyCode.W))
        {
            // If the player is not leaning up, left, and right
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Set the player to be leaning up
                isLeaningUp = true;

                // Set the position of the player to be the y-axis of the top lean navpoint
                position.y = topLeanNavPoint.transform.position.y;
            }
        }

        if (isLeaningUp == true)
        {
            // If the player releases the lean up button
            if (Input.GetKeyUp(KeyCode.W))
            {
                // Set the player to not be leaning up
                isLeaningUp = false;

                // Set the player's position to be it's starting point
                position = startingPos;
            }
        }




        // If the player presses the lean left button
        if (Input.GetKeyDown(KeyCode.A))
        {
            // If the player is not leaning up, left, and right
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Set the player to be leaning left
                isLeaningLeft = true;

                // Set the position of the player to be the x-axis of the left lean navpoint
                position.x = leftLeanNavPoint.transform.position.x;
            }
        }

        if (isLeaningLeft == true)
        {
            // If the player releases the lean left button
            if (Input.GetKeyUp(KeyCode.A))
            {
                // Set the player to not be leaning left
                isLeaningLeft = false;

                // Set the player's position to be it's starting point
                position = startingPos;
            }
        }



        // If the player presses the lean right button
        if (Input.GetKeyDown(KeyCode.D))
        {
            // If the player is not leaning up, left, and right
            if (isLeaningUp == false && isLeaningLeft == false && isLeaningRight == false)
            {
                // Set the player to be leaning right
                isLeaningRight = true;

                // Set the position of the player to be the x-axis of the right lean navpoint
                position.x = rightLeanNavPoint.transform.position.x;
            }
        }

        if (isLeaningRight == true)
        {
            // If the player releases the lean right button
            if (Input.GetKeyUp(KeyCode.D))
            {
                // Set the player to not be leaning right
                isLeaningRight = false;

                // Set the player's position to be it's starting point
                position = startingPos;
            }
        }

        // Always blend to the player's position
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * leanAnimSpeed);
    }


    // Draw debug shapes
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.75f);
    }
}

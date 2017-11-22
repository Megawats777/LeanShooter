using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Target : MonoBehaviour
{
    /*--Score properties--*/

    [Header("Score Properties")]
    public int damagedScoreValue = 10;
    public int destroyedScoreValue = 20;


    /*--Health properties--*/
    public int maxHealth = 2;
    public int minHealth = 1;
    private int health = 2;
    [SerializeField]
    private Text healthDisplayText;

    // Scale animation speed
    public float scaleAnimSpeed = 8.0f;

    // The current scale
    [HideInInspector]
    public Vector3 scale = Vector3.zero;

    // Is the target enabled
    public bool isEnabled = false;

    // The target's current lane position
    public LanePositions lanePosition;


    /*--External references--*/
    private PlayerCharacter player;


    // Called before start
    private void Awake()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    // Use this for initialization
    void Start()
    {
        if (healthDisplayText == null)
        {
            print("Test");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the target is enabled
        // Always blend to the desired scale
        if (isEnabled == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * scaleAnimSpeed);
        }

        // Otherwise
        // Snap to the desired scale
        else
        {
            transform.localScale = scale;
        }
    }

    // Damage this target
    public void damageTarget()
    {
        health--;
        updateHealthDisplayText();
        print(lanePosition.ToString() + " target damaged!");

        // If the health of the target is greater than 0
        if (health > 0)
        {
            // Add to the player's score and multiplier
            player.increaseScore(damagedScoreValue);
            player.increaseScoreMulitplier(1);
        }

        // If the health of the target is less than or equal to 0
        else if (health <= 0)
        {
            player.increaseScore(destroyedScoreValue);
            player.increaseScoreMulitplier(1);
            print("Target Destroyed");

            // Disable this target
            disableTarget();
        }
    }

    // Enable the target
    public void enableTarget()
    {
        // Set the health of this target
        setTargetHealth();

        // Set the scale of the target to 1
        scale = Vector3.one;

        // Set this target as enabled
        isEnabled = true;
    }

    // Disable the target
    public void disableTarget()
    {
        // Set the scale of the target to zero
        scale = Vector3.zero;

        // Set this target as disabled
        isEnabled = false;
    }

    // Set the health of this target
    public void setTargetHealth()
    {
        // Pick a random number between the min and max health value for this target's health value
        health = Random.Range(minHealth, maxHealth + 1);
        updateHealthDisplayText();
    }

    // Update the health display text
    private void updateHealthDisplayText()
    {
        healthDisplayText.text = health.ToString();
    }
}

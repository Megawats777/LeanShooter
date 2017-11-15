using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Scale animation speed
    public float scaleAnimSpeed = 8.0f;

    // The current scale
    [HideInInspector]
    public Vector3 scale = Vector3.zero;

    // Is the target enabled
    public bool isEnabled = false;

    // The target's current lane position
    public LanePositions lanePosition;



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

    // Enable the target
    public void enableTarget()
    {
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
}

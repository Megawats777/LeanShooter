using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    // A list of all the target's in the level
    public Target[] targetList;

    // The target to destroy
    [HideInInspector]
    public Target targetToDestroy;

    // The previous selection index num
    private int previousSelectionIndexNum = -1;


    // List of target visibility indicators
    public GameObject middleVisibilityIndicator;
    public GameObject leftVisibilityIndicator;
    public GameObject rightVisibilityIndicator;



    // Called before start
    private void Awake()
    {
        targetList = FindObjectsOfType<Target>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Select a target to enable
    public void selectTargetToEnable()
    {
        LanePositions targetLanePosition;
        int selectionIndex = Random.Range(0, targetList.Length);

        // If the selection index is the same as the previous selection index num
        // Get another selection index
        if (selectionIndex == previousSelectionIndexNum)
        {
            selectTargetToEnable();
        }

        // Otherwise spawn the selected target
        else
        {
            previousSelectionIndexNum = selectionIndex;
            targetList[selectionIndex].enableTarget();
            targetToDestroy = targetList[selectionIndex];
            targetLanePosition = targetList[selectionIndex].lanePosition;


            // If the current target lane position is middle
            // Enable the middle visibility indicator
            // Disable the left and right visibility indicator
            if (targetLanePosition == LanePositions.Middle)
            {
                middleVisibilityIndicator.SetActive(true);
                leftVisibilityIndicator.SetActive(false);
                rightVisibilityIndicator.SetActive(false);
            }

            // If the current target lane position is left
            // Enable the left visibility indicator
            // Disable the right and middle visibility indicator
            else if (targetLanePosition == LanePositions.Left)
            {
                leftVisibilityIndicator.SetActive(true);
                rightVisibilityIndicator.SetActive(false);
                middleVisibilityIndicator.SetActive(false);
            }

            // If the current target lane position is right
            // Enable the right visibility indicator
            // Disable the left and middle visibility indicator
            else if (targetLanePosition == LanePositions.Right)
            {
                rightVisibilityIndicator.SetActive(true);
                leftVisibilityIndicator.SetActive(false);
                middleVisibilityIndicator.SetActive(false);
            }
        }
    }

    // Perform a check on if a new target should be enabled
    public void performNewEnabledTargetCheck()
    {
        // If the current target to destroy is disabled
        // Enable a new target
        if (targetToDestroy.isEnabled == false)
        {
            selectTargetToEnable();
        }
    }
}

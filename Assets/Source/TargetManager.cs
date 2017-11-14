using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    // A list of all the target's in the level
    private Target[] targetList;

    // The target to destroy
    [HideInInspector]
    public Target targetToDestroy;

    // The previous selection index num
    private int previousSelectionIndexNum = -1;

    // Called before start
    private void Awake()
    {
        targetList = FindObjectsOfType<Target>();
    }

    // Use this for initialization
    void Start()
    {
        selectTargetToEnable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Select a target to enable
    public void selectTargetToEnable()
    {
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
        }
    }
}

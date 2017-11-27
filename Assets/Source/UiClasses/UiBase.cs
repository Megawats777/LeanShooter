using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBase : MonoBehaviour
{
    // Content root
    public GameObject contentRoot;

    // Show Ui
    public virtual void showUi()
    {
        contentRoot.SetActive(true);
    }

    // Hide Ui
    public virtual void hideUi()
    {
        contentRoot.SetActive(false);
    }
    
}

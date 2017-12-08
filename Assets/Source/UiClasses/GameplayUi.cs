using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUi : UiBase
{
    // Ui element refernces
    public Text winStreakText;

    private void Start()
    {
        base.Start();
        winStreakText.text = WinStreakManager.getWinStreak().ToString();        
    }

    // A function called every frame
    void Update()
    {
        
    }

    // Set the content of the ui
    private void updateUiContent()
    {
        
    }

}

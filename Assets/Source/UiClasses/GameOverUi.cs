using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUi : UiBase
{

    /*--Ui element references--*/
    public Button restartButton;
    public Button quitButton;


    // Use this for initialization
    void Start()
    {
        hideUi();

        restartButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        quitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }


}

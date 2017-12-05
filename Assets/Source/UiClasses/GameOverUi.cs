using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUi : UiBase
{
    GameStateController gameStateController;

    /*--Ui element references--*/
    public Button restartButton;
    public Button quitButton;
    public Text title;

    // Called before start
    private void Awake()
    {
        gameStateController = FindObjectOfType<GameStateController>();
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
        hideUi();

        restartButton.onClick.AddListener(delegate
        {
            gameStateController.restartGame();
        });

        quitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }


}

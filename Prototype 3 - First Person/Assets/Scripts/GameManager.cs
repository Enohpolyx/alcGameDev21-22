using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;
    
    // Instance of Game Manager
    public static GameManager instance;
    
    void Awake()
    {
        // Set the instance of this script
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        // If gamePaused == true, then set timeScale to 0, otherwise, set timeScale to 1
        Time.timeScale = gamePaused == true? 0.0f : 1.0f;

        // Toggle pause menu
        UIController.instance.TogglePauseMenu(gamePaused);

        // Toggle cursor
        Cursor.lockState = gamePaused == true? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        // Update score text
        curScore += score;
        UIController.instance.UpdateScoreText(curScore);

        // Did ya win yet?
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        // Set the screen
        UIController.instance.SetEndGameScreen(true, curScore);    
        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        UIController.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;
    public bool pausable = true;

    private AudioSource audioSource;
    public AudioSource endAudioSource;
    public AudioClip pauseSFX;
    
    // Instance of Game Manager
    public static GameManager instance;
    
    void Awake()
    {
        // Set the instance of this script
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && pausable)
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;

        if(gamePaused)
            audioSource.volume /= 4;
        else
            audioSource.volume *= 4;

        audioSource.PlayOneShot(pauseSFX, 1f);

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
        // if(curScore >= scoreToWin)
        //     WinGame();
    }

    public void WinGame()
    {
        // Set the screen
        pausable = false;
        UIController.instance.SetEndGameScreen(true, curScore);    
        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Stop();
        endAudioSource.Play();
    }

    public void LoseGame()
    {
        pausable = false;
        UIController.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Stop();
        endAudioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSFX;
    
    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPlayButton()
    {
        audioSource.PlayOneShot(clickSFX, 1f);
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButton()
    {
        audioSource.PlayOneShot(clickSFX, 1f);
        Application.Quit();
    }

    public void onMenuButton()
    {
        audioSource.PlayOneShot(clickSFX, 1f);
        SceneManager.LoadScene("Menu");
    }
}

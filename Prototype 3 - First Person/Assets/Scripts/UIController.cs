using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("HUD")]
        public GameObject HUD;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI ammoText;
        public Image healthBarFill;

    [Header("Pause Menu")]
        public GameObject pauseMenu;

    [Header("End of Game")]
        public GameObject endGameScreen;
        public TextMeshProUGUI endGameHeaderText;
        public TextMeshProUGUI endGameScoreText;

    // Instance
    public static UIController instance;
    
    void Awake()
    {
        instance = this;
        endGameScreen.SetActive(false);
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHPFill(int toDecrease)
    {
        //healthBarFill.fillAmount = curHP / maxHP;
        healthBarFill.fillAmount -= toDecrease/100f;
    }

    public void IncreaseHPFill(int toIncrease)
    {
        healthBarFill.fillAmount += toIncrease/100f;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen(bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true? "You Win" : "You Lose!";
        endGameHeaderText.color = won == true? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score.ToString();
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

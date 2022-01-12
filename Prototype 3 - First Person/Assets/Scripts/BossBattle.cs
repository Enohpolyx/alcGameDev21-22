using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour
{
    public bool filling = false;
    public Image bossBar;

    public GameObject BossBlock;
    public AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {
        if(filling)
        {
            UIController.instance.IncreaseBossHPFill(1);
        }

        if(bossBar.fillAmount == 1)
        {
            filling = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UIController.instance.BossTime();
            filling = true;

            BossBlock.SetActive(true);
            audioSource.Play();

        }    
    }
}

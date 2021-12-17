using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPShower : MonoBehaviour
{
    public AudioSource audioSource;

    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
                player.GiveHealth(1);
                UIController.instance.IncreaseHPFill(1);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}

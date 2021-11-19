using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShower : MonoBehaviour
{
    void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
                player.GiveAmmo(1);
        } 
    }
}

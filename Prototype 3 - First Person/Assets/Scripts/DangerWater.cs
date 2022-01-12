using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerWater : MonoBehaviour
{
    //If the player falls in the water, they die
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Ded();
        }    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    
    //Destroys object when it disappears
    void OnBecameInvisible(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        if(!other.gameObject.CompareTag("Player")){
                gameObject.SetActive(false);;
            }
    }

}

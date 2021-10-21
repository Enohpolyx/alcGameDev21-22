using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    
    //Destroys object when it disappears
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){
        if(!other.gameObject.CompareTag("Player")){
                Destroy(gameObject);
            }
    }

}

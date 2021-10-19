using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    
    //Destroys object when it disappears
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}

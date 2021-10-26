using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int health;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Projectile") & health <= 1 ){
                Destroy(gameObject);
            }

            else{
                health--;
            }
    }
    
}
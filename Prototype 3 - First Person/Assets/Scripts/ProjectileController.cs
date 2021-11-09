using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;


    void OnEnable()
    {
        shootTime = Time.time;
    }


    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }    
    

    void OnTriggerEnter(Collider other)
    {
        //Did we hit the target?
        // try
        // {    if(other.gameObject.CompareTag("Player"))
        //             other.GetComponent<PlayerController>().TakeDamage(damage);
            
        //     else if(other.CompareTag("Enemy"))
        //             other.GetComponent<EnemyController>().TakeDamage(damage);
            
        //     else if(other.CompareTag("Destructible"))
        //         other.GetComponent<Destructible>().TakeDamage(damage);

        //     else
        //         gameObject.SetActive(false);
        // }
        // catch
        // {
        //     gameObject.SetActive(false);
        // }

        // finally
        // {
        //     gameObject.SetActive(false);
        // }

    // if(other.gameObject.CompareTag("Player"))
    //     other.GetComponent<PlayerController>().TakeDamage(damage);
            
    // if(other.CompareTag("Enemy"))
    //     other.GetComponent<EnemyController>().TakeDamage(damage);
            
    // if(other.CompareTag("Destructible"))
    //     other.GetComponent<Destructible>().TakeDamage(damage);

    
    gameObject.SetActive(false);

    }

}

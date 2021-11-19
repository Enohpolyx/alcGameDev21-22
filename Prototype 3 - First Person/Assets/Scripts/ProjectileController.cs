using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject hitParticle;


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
    //Create hit particle effect
    GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
    //Destroy particle effect after .5 seconds
    Destroy(obj, 0.5f);

    
    //Detect which object is hit
    if(other.gameObject.CompareTag("Player"))
        other.GetComponent<PlayerController>().TakeDamage(damage);
            
    else if(other.CompareTag("Enemy"))
        other.GetComponent<EnemyController>().TakeDamage(damage);
            
    else if(other.CompareTag("Destructible"))
        other.GetComponent<Destructible>().TakeDamage(damage);
    
    else if(other.CompareTag("Prezzie"))
        other.GetComponent<Prezzie>().TakeDamage(damage);
    
    //Broken
    // else if(other.gameObject.CompareTag("Eye"))
    //     other.GetComponentInParent<EnemyController>().TakeDamage(damage*2);

    else
        gameObject.SetActive(false);
    }

}

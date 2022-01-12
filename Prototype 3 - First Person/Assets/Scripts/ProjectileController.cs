using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject hitParticle;
    public GameObject BossCritParticle;


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
    if(!other.gameObject.CompareTag("BattleZone"))
        {
        //Create hit particle effect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        //Destroy particle effect after .5 seconds
        Destroy(obj, 0.5f);
        }


    //Detect which object is hit
    if(other.gameObject.CompareTag("Player"))
        {
        other.GetComponent<PlayerController>().TakeDamage(damage);
        gameObject.SetActive(false);
        }
            
    else if(other.CompareTag("Enemy"))
        {
        other.GetComponent<EnemyController>().TakeDamage(damage);
        gameObject.SetActive(false);
        }
            
    else if(other.CompareTag("Destructible"))
        {
        other.GetComponent<Destructible>().TakeDamage(damage);
        gameObject.SetActive(false);
        }
    
    else if(other.CompareTag("Prezzie"))
        {
        other.GetComponent<Prezzie>().TakeDamage(damage);
        gameObject.SetActive(false);
        }
    
    else if(other.CompareTag("Boss"))
        {
        other.GetComponent<BossController>().TakeDamage(damage);
        gameObject.SetActive(false);
        }

    else if(other.CompareTag("BossEye"))
        {
        other.GetComponentInParent<BossController>().TakeDamage(damage*3);
        GameObject obj = Instantiate(BossCritParticle, transform.position, Quaternion.identity);
        //Destroy particle effect after .5 seconds
        Destroy(obj, 0.5f);
        gameObject.SetActive(false);
        }
    
    else if(other.gameObject.CompareTag("Eye"))
        other.GetComponentInParent<EnemyController>().TakeDamage(damage*2);

    else if(other.gameObject.CompareTag("BattleZone")){}

    else
        gameObject.SetActive(false);
    }

}

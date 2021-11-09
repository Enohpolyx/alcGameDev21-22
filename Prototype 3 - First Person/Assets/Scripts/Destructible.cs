using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int maxHP;
    public int curHP;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Ded();
    }

    void Ded()
    {
        Destroy(gameObject);
    }

    // void OnTriggerEnter(Collider other)
    //     {
    //         if(other.gameObject.CompareTag("Projectile") & health <= 1 ){
    //             Destroy(gameObject);
    //         }

    //         else{
    //             health--;
    //         }
    // }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile"))
            TakeDamage(1);
            //other.setActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public GameObject hitParticle;
    private void Awake()
    {
        
    }
    
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
        if(other.gameObject.CompareTag("Projectile"))
            GetComponentInParent<EnemyController>().TakeDamage(other.GetComponent<ProjectileController>().damage*2);
            //other.setActive(false);

        //Create hit particle effect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        //Destroy particle effect after 1 second
        Destroy(obj, 1.0f);
    }
}

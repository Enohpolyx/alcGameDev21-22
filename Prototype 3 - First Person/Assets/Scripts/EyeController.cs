using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
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
    }
}

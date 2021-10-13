using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    

    
    public GameObject projPrefab;
    public Transform muzzle;
    public float bulletSpeed;
    
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        //is projectile attatched to the player
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo)
            {
                return true;
            }
        }

        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;
        GameObject projectile = Instantiate(projPrefab, muzzle.position, muzzle.rotation);

        //set the velocity
        projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

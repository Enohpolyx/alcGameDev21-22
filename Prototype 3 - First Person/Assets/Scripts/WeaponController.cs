using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    

    
    public GameObject projPrefab;
    public Transform muzzle;
    public Transform muzzle2;
    public float bulletSpeed;

    private string lastUsed;
    
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
            lastUsed = "Right";
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
        
        if(lastUsed == "Right"){

            GameObject projectile = Instantiate(projPrefab, muzzle.position, muzzle.rotation);
            projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
            lastUsed = "Left";
        }

        else if(lastUsed == "Left"){
            GameObject projectile = Instantiate(projPrefab, muzzle2.position, muzzle.rotation);
            projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
            lastUsed = "Right";

        }

        //set the velocity
        //projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

    }
    
}

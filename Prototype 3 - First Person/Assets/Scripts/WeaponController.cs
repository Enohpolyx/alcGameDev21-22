using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    

    
    public ObjectPool projPool;
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

    private Rigidbody daRigidbody;


    void Awake()
    {
        //is projectile attatched to the player
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
        lastUsed = "Right";
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

            // Retrieve object from the pool and fire it
            GameObject projectile = projPool.GetObject();
            projectile.transform.position = muzzle.position;
            //projectile.transform.rotation = muzzle.rotation;

            projectile.transform.eulerAngles = new Vector3(muzzle.transform.eulerAngles.x + 90, muzzle.transform.eulerAngles.y, muzzle.transform.eulerAngles.z);
            
            daRigidbody = projectile.GetComponent<Rigidbody>();
            daRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
            
            lastUsed = "Left";
        }

        else if(lastUsed == "Left"){
            GameObject projectile = projPool.GetObject();
            projectile.transform.position = muzzle2.position;
            // projectile.transform.rotation = muzzle2.rotation;

            projectile.transform.eulerAngles = new Vector3(muzzle.transform.eulerAngles.x + 90, muzzle.transform.eulerAngles.y, muzzle.transform.eulerAngles.z);

            daRigidbody = projectile.GetComponent<Rigidbody>();
            daRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            
            projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
            
            lastUsed = "Right";

            if(isPlayer)
                UIController.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }

        //set the velocity
        //projectile.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

    }
    
}

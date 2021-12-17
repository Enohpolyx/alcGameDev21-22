using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity; //Mouse sensitivity
    public float maxLookX; //Lowest down position
    public float minLookX; //Highest up position
    private float rotX; //Current X rotation
    
    //GameObjects & Components
    private Camera cam;
    private Rigidbody rigby;

    private WeaponController weapon;

    [Header("Stats")]
    public int curHP;
    public int maxHP;


    // Called Before Start
    void Awake()
    {
        //Get components
        cam = Camera.main;
        rigby = GetComponent<Rigidbody>();
        weapon = GetComponent<WeaponController>();

        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        //Initailize the UI
        //UIController.instance.UpdateHPFill(curHP, maxHP);
        UIController.instance.UpdateScoreText(0);
        UIController.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
    
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        UIController.instance.DecreaseHPFill(damage);

        if(curHP <= 0)
            Ded();
    }

    void Ded()
    {
        GameManager.instance.LoseGame();
    }


    // Decreas is called once per frame
    void Update()
    {
        // Don't do anything when game is paused
        if(GameManager.instance.gamePaused)
            return;
        
        
        Move();
        CamLook();
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //face the direction of the camera and jump that way too
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rigby.velocity.y;
        //Move in the desired direction
        rigby.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.1f))
        {
            rigby.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        //Clamps the camera's up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //Apply rotX to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Projectile"))
    //         TakeDamage(1);
    //         //other.setActive(false);
    // }

    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        UIController.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}

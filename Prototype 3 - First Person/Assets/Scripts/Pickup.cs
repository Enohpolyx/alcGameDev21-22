using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{   
    [Header ("Values")]
    public PickupType type;
    public int value;

    [Header ("Bobbing Animation")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private bool bobbingUp;

    public AudioClip pickupSFX;


    void Start() 
    {
        //Set the start position
        startPos = transform.position;
    }

    void Update()
    {
        //Rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //Bobbing
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight/2, 0) : new Vector3(0, -bobHeight/2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }

    void OnTriggerEnter(Collider other)
    {
        //If the player touches it, determine which pickup it is and award the player
        if(other.CompareTag("Player"))
            {
                PlayerController player = other.GetComponent<PlayerController>();

                switch(type)
                {
                    case PickupType.Health:
                        player.GiveHealth(value);
                        UIController.instance.IncreaseHPFill(value);
                        break;
                    case PickupType.Ammo:
                        player.GiveAmmo(value);
                        break;
                }

                //Play audio clip on the player
                other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);

                Destroy(gameObject);
            }
    }
}

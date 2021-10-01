using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    public string pickUpName;
    public int amount;
    public bool isPickedUp;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            
            print("You picked up a " + pickUpName +"!");
            isPickedUp = true;
            gameManager.hasKey = true;

            Destroy(gameObject);
        }
    }

}

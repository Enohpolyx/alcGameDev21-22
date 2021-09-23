using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private float xRange = 11.2f;
    private float yRange = 6.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets boundaries on left and right sides of the screen
        if(transform.position.x > xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Sets boundaries on top and bottom of screen
        if(transform.position.y > yRange) {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if(transform.position.y < -yRange) {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("MagicMissile")){
            Destroy(gameObject);
        }
    }
}

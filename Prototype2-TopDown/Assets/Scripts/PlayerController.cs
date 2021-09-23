using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hInput;
    public float vInput;

    private float xRange = 11.5f;
    private float yRange = 6.5f;

    public GameObject Projectile;
    private Vector3 offset = new Vector3(1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //Getting keyboard input
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //Makes player move left and right
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
        
        //Makes the player move up and down
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);

        
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

        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(Projectile, transform.position + offset, Projectile.transform.rotation);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float hInput;
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        //Getting keyboard input
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //Makes player move in the inputted direction
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
    }
}

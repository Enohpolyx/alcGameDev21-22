using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float moveSpeed;

    //Camera Vars
    public float lookSensitivity; //Mouse sensitivity
    public float maxLookX; //Lowest down position
    public float minLookX; //Highest up position
    private float rotX; //Current X rotation
    
    //GameObjects & Components
    private Camera cam;
    private Rigidbody rigby;

    // Called Before Start
    void Awake()
    {
        //Get components
        cam = Camera.main;
        rigby = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rigby.velocity = new Vector3(x, rigby.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX = Input.GetAxis("Mouse Y") * lookSensitivity;

        //Clamps the camera's up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //Apply rotX to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
}

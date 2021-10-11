using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    public float jumpForce;

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
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
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
}

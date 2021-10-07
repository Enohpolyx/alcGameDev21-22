using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tank;
    private Vector3 offset = new Vector3(0, 14, -22);
    private Quaternion rotateThing;

    // Update is called once per frame
    void Update()
    {
        //set the camera's position to the tank's position
        transform.position = tank.transform.position + offset;

    }

    


}



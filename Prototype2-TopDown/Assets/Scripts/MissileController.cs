using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    
    public float speed = 5.0f;
    
    public Transform player;

    public Transform target;
    private Vector3 targetLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, Vector3.forward);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        //targetLock = Target.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, targetLock, speed * Time.deltaTime);
        
    }
}

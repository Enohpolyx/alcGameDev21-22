using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    
    public float speed = 10.0f;
    public float hInput;
    public float vInput;
    
    public Transform player;

    public Transform target;
    private Vector3 targetLock;

    private string direction = "RIGHT";

    // Start is called before the first frame update
    void Start()
    {
        
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (vInput > 0){
            direction = "UP";
        }
        
        else if (vInput < 0){
            direction = "DOWN";
        }
        
        else if (hInput < 0){
            direction = "LEFT";
        }
        
        else if (hInput > 0){
            direction = "RIGHT";
        }

        else {
            direction = "RIGHT";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (direction == "UP"){
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
        
        if (direction == "DOWN"){
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
        
        if (direction == "LEFT"){
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        
        if (direction == "RIGHT"){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }




        //transform.LookAt(target, Vector3.forward);
        
        //targetLock = Target.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, targetLock, speed * Time.deltaTime);
        
    }

    void FixedUpdate(){
        if(!GetComponent<Renderer>().isVisible){
            Destroy(gameObject);
        }
    }    
    
    void OnBecameInvisible() {
         Destroy(gameObject);
     }

    void OnTriggerEnter2D(Collider2D other) { 
        
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private float xRange = 11.2f;
    private float yRange = 6.0f;
    public float moveSpeed= 5.0f;
    
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        
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

    private void FixedUpdate(){
        moveCharacter(movement);
    }
    
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

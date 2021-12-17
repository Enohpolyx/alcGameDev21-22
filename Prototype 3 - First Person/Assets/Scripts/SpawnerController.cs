using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject child;
    public float spawnSpeed;
    public float spawnRange;
    private GameObject target;

    public float curHP;
    private bool isDead = false;
    public int scoreToGive;

    public bool inRange;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("Spawn", 0, spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < spawnRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    void Spawn()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(!isDead && dist <= spawnRange)
            Instantiate(child, transform.position, transform.rotation);
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Ded();
    }

    void Ded()
    {
        isDead = true;
        GameManager.instance.AddScore(scoreToGive);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile"))
            TakeDamage(1);
    }
}

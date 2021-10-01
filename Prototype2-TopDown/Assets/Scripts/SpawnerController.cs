using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject Enemy;
    public float Timer = 1.0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        
        if (Timer <= 0){
            Instantiate(Enemy, transform.position, Enemy.transform.rotation);

            Timer = 1.0f;
        }

    }
}

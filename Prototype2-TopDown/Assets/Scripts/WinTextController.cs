using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTextController : MonoBehaviour
{
    
    public GameManager gameManager;
    public bool rendered = false;
    public GameObject textThing;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.isDoorLocked & !rendered){
            Instantiate(textThing, transform.position, textThing.transform.rotation);
            rendered = true;
        }

    }
}

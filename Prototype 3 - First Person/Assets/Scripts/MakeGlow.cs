using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGlow : MonoBehaviour
{
    
    private MeshRenderer meshy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        meshy = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshy.material.EnableKeyword("_EMISSION");   
    }
}

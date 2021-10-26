using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    public int createOnStart;
    
    private List<GameObject> objPool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < createOnStart; i ++)
        {
            CreateNewObject();
        }
    }

    // Creates and returns a deactivated GameObject
    GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        objPool.Add(obj);

        return obj;
    }

    // Find and return an object
    public GameObject GetObject()
    {
        GameObject obj = objPool.Find(x => x.activeInHierarchy == false);
        
        if(obj == null)
        {
            obj = CreateNewObject();
        }

        obj.SetActive(true);

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

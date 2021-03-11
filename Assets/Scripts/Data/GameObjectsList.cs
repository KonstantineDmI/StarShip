using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsList : MonoBehaviour
{
    public static GameObjectsList instance = null;
    public List<GameObject> allObjects = new List<GameObject>();

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void Awake()
    {
       
        if (instance == null)
            instance = this;

        
        else if (instance != this)
            Destroy(gameObject);
    }
}

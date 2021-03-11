using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsList : MonoBehaviour
{

    public static ObjectsList instance = null;
    public List<GameObject> allObjects = new List<GameObject>();

    void Awake()
    {
        
        if (instance == null)
            instance = this;


        else if (instance != this)
            Destroy(gameObject);
    }
}

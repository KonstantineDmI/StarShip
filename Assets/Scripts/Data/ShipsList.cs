using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsList : MonoBehaviour
{
    public static ShipsList instance = null;
    public List<GameObject> allShips = new List<GameObject>();

   
    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
}

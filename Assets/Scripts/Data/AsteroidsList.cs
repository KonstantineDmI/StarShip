using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsList : MonoBehaviour
{
    public static AsteroidsList instance = null;
    public List<GameObject> allAsteroids = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    public List<GameObject> planetList;
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            float scale = Random.Range(0.5f, 1);
            int randPlanet = Random.Range(0, 2);
            scaleChange = new Vector3(scale, scale, scale);
            planetList[randPlanet].transform.localScale = scaleChange;
            Instantiate(planetList[randPlanet], new Vector2(Random.Range(-4.1f, 4.1f), 8.3f), Quaternion.identity);
        }
    }

    
    

    
}

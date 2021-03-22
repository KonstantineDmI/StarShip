using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    public static bool asteroidTime;
    private GameObject _alert;
    private void Start()
    {
        _alert = GameObjectsList.instance.allObjects[0].gameObject;
        asteroidTime = false;
        StartCoroutine(AsteroidTime());
    }
   

    IEnumerator Spawn()
    {
        while(asteroidTime)
        {
            AsteroidTimeOn();
            StartCoroutine(AsteroidTimeCheck());
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(AsteroidTime());
    }

    IEnumerator AsteroidTime()
    {
        if(SpawnPlayer.currentShip != null)
        {
            yield return new WaitForSeconds(Random.Range(60f, 120f));
            _alert.SetActive(true);
            _alert.GetComponent<AlertPanel>().Animate("Meteorites are coming!");
            yield return new WaitForSeconds(5f);
            _alert.SetActive(false);
            asteroidTime = true;
            StartCoroutine(Spawn());
        } 
    }

    IEnumerator AsteroidTimeCheck()
    {
        yield return new WaitForSeconds(20f);
        if(asteroidTime == true) asteroidTime = false;
    }

    



    void AsteroidTimeOn()
    {
        Instantiate(AsteroidsList.instance.allAsteroids[Random.Range(0, 2)], new Vector3(Random.Range(-2.5f, 2.5f), 5.6f, 0f), Quaternion.identity);
    }
    
}

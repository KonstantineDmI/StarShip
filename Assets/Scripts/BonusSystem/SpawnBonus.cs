using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{ 
    public GameObject weaponBox;
    public GameObject healBox;
    public GameObject coin;

    [SerializeField]
    private float _timeWeaponBox = 10f;

    [SerializeField]
    private float _timeHealBox = 7f;

    [SerializeField]
    private float _timeCoin = 11f;


   
    void Start()
    {
        StartCoroutine(SpawnShBonus());
        StartCoroutine(SpawnHealBox());
        StartCoroutine(SpawnCoins());
    }
    
    IEnumerator SpawnShBonus()
    {
        
        while (true)
        {
            _timeWeaponBox = Random.Range(15f, 40f);
            yield return new WaitForSeconds(_timeWeaponBox);
            Instantiate(weaponBox, new Vector3(Random.Range(-2.5f, 2.5f), 5.9f, - 0.7f), Quaternion.identity);
            
        }
       
    }

    IEnumerator SpawnHealBox()
    {

        while (true)
        {
            _timeHealBox = Random.Range(15f, 40f);
            yield return new WaitForSeconds(_timeHealBox);
            Instantiate(healBox, new Vector3(Random.Range(-2.5f, 2.5f), 5.9f, -0.7f), Quaternion.identity);

        }

    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            _timeCoin = Random.Range(10, 15);
            yield return new WaitForSeconds(_timeCoin);
            Instantiate(coin, new Vector3(Random.Range(-2.5f, 2.5f), 5.9f, -0.7f), Quaternion.identity);


        }
    }





}

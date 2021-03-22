using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField]
    private float  _speed = 2f;

    public GameObject bullet;

    void Start()
    {
        bullet = SpawnPlayer.currentShip.GetComponent<Player>().bullet;
    }


    void Update()
    {
        transform.position -= new Vector3(0f, _speed * Time.deltaTime);
        transform.Rotate(new Vector3(45, 45, 0) * _speed * Time.deltaTime);

      
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.GetComponent<Player>() != null)
        {
            Destroy(gameObject);
            bullet.GetComponent<Bullet>().advanced = true;
            Player.shootingTimerOn = true;
            
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{
    public int enemyHP;
    public int enemyDamage;
    public float speed;

    private GameObject player;

    public GameObject bullet;
    public GameObject enemyDestroy;
    public GameObject enemyHit;

    public float offset;

    private Vector3 _targetPos;
    private Vector3 _thisPos;
    private float _angle;



    void Start()
    {
        enemyHP = 100;
        speed = Random.Range(1f, 10f);
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        player = SpawnPlayer.currentShip;
        StartCoroutine(Shooting());
    }

    public Enemy()
    {

    }

    void Update()
    {
        if (player.gameObject != null)
        {
            _targetPos = player.transform.position;
            _thisPos = transform.position;
            _targetPos.x -= _thisPos.x;
            _targetPos.y -= _thisPos.y;
            _angle = Mathf.Atan2(_targetPos.y, _targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle + 90));
        }
            
        
            
       
           
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 5f);
        
        //Vector2 objRot = transform.eulerAngles;
    }

    void EnemyTakeDamage(int damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            Instantiate(enemyDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(2f, 1f, 0.05f, 0.5f);

        }
        else
        {
            Instantiate(enemyHit, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            EnemyTakeDamage(other.gameObject.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }

    }

    IEnumerator Shooting()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(2f);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);   
        }
        
    }
    
}

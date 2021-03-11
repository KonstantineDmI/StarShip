using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.7f;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Vector3 _position;

    [SerializeField]
    private int _damage;
    void Start()
    {

        _player = SpawnPlayer.currentShip.transform;
        _position = transform.position - _player.transform.position;
        transform.LookAt(_player.transform);
        _damage = Random.Range(10, 20);
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {


        if (transform.position.y < -5.6f)
        {
            Destroy(gameObject);
        }

        defaultShooting();
        
    }

    void defaultShooting()
    { 
        transform.position -= new Vector3(_position.x, _position.y, _position.z)  * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Destroy(gameObject);
            other.GetComponent<Player>().TakeDamage(_damage);
            other.GetComponent<Player>().GameOver();
            Player.gameOver = true;
        }

    }


}

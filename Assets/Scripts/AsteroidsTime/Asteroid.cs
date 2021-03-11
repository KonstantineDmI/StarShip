using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotSpeed = 0.5f;

    [SerializeField]
    private int _damage = 10;


    public GameObject asteroidDestroy;

    void Start()
    {
        _speed = Random.Range(2f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, _speed * Time.deltaTime);

        transform.Rotate(new Vector3(45, 90, 0) * _rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Destroy(this.gameObject);
            Instantiate(asteroidDestroy, transform.position, Quaternion.identity);
            other.GetComponent<Player>().TakeDamage(_damage);
            other.GetComponent<Player>().GameOver();
        }
        if(other.GetComponent<Enemy>() != null)
        {
            Instantiate(asteroidDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

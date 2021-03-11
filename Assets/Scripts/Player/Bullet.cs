using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public bool advanced;
    public int damage;

    
    // Start is called before the first frame update
    void Start()
    {
        advanced = false;
        damage = GetComponent<Damage>().bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 5.6f)
        {
            Destroy(gameObject);
        }

        defaultShooting();

    }

    void defaultShooting()
    {
        transform.position += transform.up * (speed * Time.deltaTime);
    }

   

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    public static int health;

    [SerializeField]
    private float _speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, _speed * Time.deltaTime);
        transform.Rotate(new Vector3(45, 45, 0) * _speed * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Destroy(this.gameObject);
            other.GetComponent<Player>().Heal(health);
        }
    }


}

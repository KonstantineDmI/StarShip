using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float _random;
    private float _smoothTime = 0.7f;
    private float _yVelocity = 0.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        _random = Random.Range(1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (transform.position.y > _random)
        {
            
            float newPosition = Mathf.SmoothDamp(transform.position.y, _random, ref _yVelocity, _smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

        }
        
    }



    
}

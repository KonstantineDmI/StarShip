using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    void Update()
    {
            var entity = FindObjectsOfType<Enemy>();

        if (entity.Length < 4 && CountDown.timerOn == false && AsteroidsManager.asteroidTime == false)
        {
            
            Instantiate(_enemy, new Vector2(Random.Range(-2.71f, 2.71f), 5.9f), Quaternion.Euler(0f, 0f, 0f));
        }
        
        
    }
    

    
    
}

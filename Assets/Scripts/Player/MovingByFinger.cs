using System.Collections;
using UnityEngine;

public class MovingByFinger : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _playerSpeed;

    void Start()
    {
        _player = SpawnPlayer.currentShip.transform;

        _playerSpeed = _player.GetComponent<Player>().speed;

    }


    void OnMouseDrag()
    {
        if (_player.position != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.5f ? 2.5f : mousePos.x;
            mousePos.x = mousePos.x < -2.5f ? -2.5f : mousePos.x;

            mousePos.y = mousePos.y > 4.5f ? 4.5f : mousePos.y;
            mousePos.y = mousePos.y < -4.5f ? -4.5f : mousePos.y;


            _player.position = Vector2.MoveTowards(_player.position, new Vector2(mousePos.x, mousePos.y + 0.5f),
               _playerSpeed * Time.deltaTime);
        }
        
       

       
    }

   
    
}

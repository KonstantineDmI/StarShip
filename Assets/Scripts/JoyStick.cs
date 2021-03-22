using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _playerSpeed;

    [SerializeField]
    private Transform _circle;

    [SerializeField]
    private Transform _circleField;

    private Vector2 _pointA;
    private Vector2 _pointB;

    private bool _touchStart;

    void Start()
    {
        _player = SpawnPlayer.currentShip.transform;

        _playerSpeed = _player.GetComponent<Player>().speed;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pointA = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            _circle.transform.position = _pointA * -1;
            _circleField.transform.position = _pointA * -1;

            _circle.GetComponent<SpriteRenderer>().enabled = true;
            _circleField.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            _touchStart = true;

            _pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            _circle.position = _pointB * -1;
        }
        else _touchStart = false;
        
    }

    private void FixedUpdate()
    {
        if (_touchStart)
        {
            Vector2 offset = _pointB - _pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveShip(direction * -1);

            _circle.transform.position = new Vector2(_pointA.x + direction.x, _pointA.x + direction.y) * -1;
        }
    }

    void MoveShip(Vector2 direction)
    {
        if(_player != null)
        {
            _player.Translate(direction * _playerSpeed * Time.deltaTime);
        }
        




    }


    void OnMouseDrag()
    {
        

        //if (_player.position != null)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mousePos.x = mousePos.x > 2.5f ? 2.5f : mousePos.x;
        //    mousePos.x = mousePos.x < -2.5f ? -2.5f : mousePos.x;

        //    mousePos.y = mousePos.y > 4.5f ? 4.5f : mousePos.y;
        //    mousePos.y = mousePos.y < -4.5f ? -4.5f : mousePos.y;


        //    _player.position = Vector2.MoveTowards(_player.position, new Vector2(mousePos.x, mousePos.y + 0.5f),
        //       _playerSpeed * Time.deltaTime);
        //}
    }

    private void OnMouseUp()
    {
        _circle.GetComponent<SpriteRenderer>().enabled = false;
        _circleField.GetComponent<SpriteRenderer>().enabled = false;
    }



}


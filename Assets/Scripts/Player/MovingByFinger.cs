using System.Collections;
using UnityEngine;

public class MovingByFinger : MonoBehaviour
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
    private Vector2 _circleStartPoint;

    private bool _touchStart = false;
    private bool _joyMode;

    void Start()
    {
        _player = SpawnPlayer.currentShip.transform;

        _playerSpeed = _player.GetComponent<Player>().speed;
        _circleStartPoint = _circle.position;

        if (PlayerPrefs.GetInt("joystickmode") == 0)
        {
            _joyMode = false;
            _circle.transform.GetComponent<SpriteRenderer>().enabled = false;
            _circleField.transform.GetComponent<SpriteRenderer>().enabled = false;

        }
        else
        {
            _joyMode = true;
            _circle.transform.GetComponent<SpriteRenderer>().enabled = true;
            _circleField.transform.GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    private void Update()
    {
        if(_joyMode == true)
        {
            if (Input.GetMouseButtonDown(0)) // it works single time when button was pressed
            {
                _pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

                _circle.transform.position = _circleStartPoint;

            }
            if (Input.GetMouseButton(0)) // it works every frame
            {
                _touchStart = true;

                _pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                _circle.position = _pointB;
            }
            else
            {
                _touchStart = false;
                _circle.position = _circleStartPoint;

            }
        }
        
    }

    private void FixedUpdate()
    {
        if (_touchStart && _joyMode == true) // it works every frame
        {
            Vector2 offset = _pointB - _pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveShip(direction);

            _circle.transform.position = new Vector3(_pointA.x + direction.x, _pointA.y + direction.y);
        }
    }

    void MoveShip(Vector2 direction)
    {

        if (_player.transform.position.x > 2.5) _player.transform.position = new Vector3(2.5f, _player.transform.position.y, _player.transform.position.z);
        if (_player.transform.position.x < -2.5) _player.transform.position = new Vector3(-2.5f, _player.transform.position.y, _player.transform.position.z);
        if (_player.transform.position.y > 4.5) _player.transform.position = new Vector3(_player.transform.position.x, 4.5f, _player.transform.position.z);
        if (_player.transform.position.y < -3.5) _player.transform.position = new Vector3(_player.transform.position.x, -3.5f, _player.transform.position.z);

        _player.Translate(direction * _playerSpeed * Time.deltaTime);
        




    }


    void OnMouseDrag()
    {


        if (_player != null && _joyMode == false)
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

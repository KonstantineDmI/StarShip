using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickMode : MonoBehaviour
{
    private Toggle _checkBox;
    private void Start()
    {
        _checkBox = gameObject.transform.GetComponent<Toggle>();

        if (PlayerPrefs.GetInt("joystickmode") == 0)
        {
            _checkBox.isOn = false;
        }
        else
        {
            _checkBox.isOn = true;
        }
    }
    void Update()
    {
        if (_checkBox.isOn)
        {
            PlayerPrefs.SetInt("joystickmode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("joystickmode", 0);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject panel;
    public Text countDown;
    float timer = 3;
    float currentTime = 0;
    public static bool timerOn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= 0)
        {
           
            StartCoroutine(Timer());
        }
        
    }

    IEnumerator Timer()
    {
        
        currentTime -= Time.deltaTime;
        countDown.text = Convert.ToInt32(currentTime).ToString();

        if (currentTime <= 0)
        {
            countDown.text = "Let's GO!";
            timerOn = false;
            yield return new WaitForSeconds(1f);
            panel.SetActive(false);
           
        }
    }
}

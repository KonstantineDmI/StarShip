using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FPS : MonoBehaviour
{
    public Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            float fps = 1.0f / Time.deltaTime;
            fpsText.text = Convert.ToInt32(fps).ToString();
        }
        
    }
}

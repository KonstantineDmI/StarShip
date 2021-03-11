using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public Text text;
    void Start()
    {
        score = 0;
        StartCoroutine(ScoreSystem());
        
    }

    IEnumerator ScoreSystem()
    {
        while (true)
        {
            score++;
            text.text = score + " km";
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    
}

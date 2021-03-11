using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBUpdate : MonoBehaviour
{
    

    public static int sessionCoinQuantity = 0;
    public static int sessionScore = 0;

    void Start()
    {
        sessionCoinQuantity = 0;
        sessionScore = 0;
    }

    private void Update()
    {
        sessionScore = Score.score;
    }
}

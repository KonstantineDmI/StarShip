using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEngine.UI;


public class AppStart : MonoBehaviour
{

    // Start is called before the first frame update


    public int score;
    public int coins;

    public Text coinBalance;
    public Text bestScore;
    public Text lastScore;

    public static int balForShop = 0;
    public static Item item;
    public static ShopDataBase shopDB;


    private SqliteConnection _connection;
    private string  _sqlQuery;
    private IDbCommand _dbcmd;
    private IDataReader _reader;
    private string _path;

    public void BalanceUpdate(int balance)
    {
        coinBalance.text = "Your balance: " + balance;
    }



    

    public void connections()
    {

        try
        {

            if (Application.platform != RuntimePlatform.Android)
            {

                _path = Application.dataPath + "/StreamingAssets/StarShipDB.bytes"; // Путь для Windows
            }
            else
            {
                _path = Application.persistentDataPath + "/StarShipDB.bytes"; // Путь для Android
                if (!File.Exists(_path))
                {

                    WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "StarShipDB.bytes");
                    while (!load.isDone) { }
                    File.WriteAllBytes(_path, load.bytes);
                }
            }

            _connection = new SqliteConnection("URI=file:" + _path);
            _connection.Open();
            if (_connection.State == ConnectionState.Open)
            {

                Debug.Log(_path.ToString() + " - is connected");

            }


        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }

        
        

    }

    void Start()
    {
        connections();
        BestScore();
        LastScore();
        Balance();
        item = new Item();
        shopDB = new ShopDataBase();
        Debug.Log(SpawnPlayer.shipName);
    }

    void BestScore()
    {
        connections();
        _dbcmd = _connection.CreateCommand();
        _sqlQuery = "SELECT * FROM ScoreTable ORDER BY (Score) DESC";
        _dbcmd.CommandText = _sqlQuery;
        _reader = _dbcmd.ExecuteReader();
        bestScore.text = _reader[0].ToString();
        _connection.Close();
    }

    void Balance()
    {
        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "SELECT * FROM CoinsTable";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        coinBalance.text = reader[0].ToString();
        balForShop = Convert.ToInt32(reader[0]);
        _connection.Close();
    }

    void LastScore()
    {
        connections();
        _dbcmd = _connection.CreateCommand();
        _sqlQuery = "SELECT * FROM ScoreTable";
        _dbcmd.CommandText = _sqlQuery;
        _reader = _dbcmd.ExecuteReader();
        while (_reader.Read())
        {
            lastScore.text = _reader[0].ToString();
        }
        _connection.Close();
    }




    public void DataAdding()
    {

        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "UPDATE CoinsTable SET Coins = Coins +" + DBUpdate.sessionCoinQuantity;
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        if(DBUpdate.sessionScore != 0)
        {
            dbcmd = _connection.CreateCommand();
            sqlQuery = "INSERT INTO ScoreTable (Score)  VALUES (" + DBUpdate.sessionScore + ")";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteNonQuery();
        }
        _connection.Close();


    }
    

    



    

}




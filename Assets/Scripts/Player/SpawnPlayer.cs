using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    private SqliteConnection _connection;
    private IDataReader _reader;
    private string _path;

    public static string shipName;
    public List<GameObject> allShips;
    public static GameObject currentShip;

    void Start()
    {

        SearchShip();

        for(int i = 0; i < allShips.Count; i++)
        {
            if(allShips[i].name == shipName)
            {
                allShips[i].SetActive(true);
                allShips[i].transform.position = new Vector3(0, 0, 0);
                currentShip = allShips[i].gameObject;
                break;
            }
        }

        
        

    }

    void SearchShip()
    {
        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "SELECT * FROM SelectedShip";
        dbcmd.CommandText = sqlQuery;
        _reader = dbcmd.ExecuteReader();
        shipName = _reader[0].ToString();
        _connection.Close();
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
}

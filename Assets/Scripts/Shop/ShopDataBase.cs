using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopDataBase : MonoBehaviour
{
    private SqliteConnection _connection;
    private IDataReader _reader;
    private string _path;

    public GameObject item;
    public GameObject content;
    public static int balanceForBuy;
    public static string selectedShipName;
    public static GameObject selectedShip;
 
    void Start()
    {
        connections();
        SelectedShipName();
        AddItem();
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

    
    void AddItem()
    {
        connections();
        int counter = 0; 
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "SELECT * FROM Shop ORDER BY (Cost)";
        dbcmd.CommandText = sqlQuery;
        _reader = dbcmd.ExecuteReader();
        while (_reader.Read())
        {
            
            Text name = item.transform.GetChild(0).GetChild(3).GetComponent<Text>();
            Text cost = item.transform.GetChild(0).GetChild(4).GetComponent<Text>();
            name.text = _reader[1].ToString();
            cost.text = _reader[2].ToString();

            item.transform.GetChild(0).GetComponentInChildren<Ship>().shipGo = ShipsList.instance.allShips[counter].gameObject;
            IsLocked();
            GameObject go = (GameObject)Instantiate(item, content.transform, false);
            GameObject image = item.transform.GetChild(0).GetChild(1).gameObject;

            if (name.text == selectedShipName)
            {
                ObjectsList.instance.allObjects[3].transform.SetParent(go.transform);
                ObjectsList.instance.allObjects[3].transform.position = new Vector3(go.transform.position.x - 100, go.transform.position.y - 15, go.transform.position.z);
            }



            //image.GetComponent<Image>().sprite = Resources.Load<Sprite>("ship");
            counter++;
        }
        _connection.Close();
        _reader.Close();




    }


    void IsLocked()
    {
        if (Convert.ToInt32(_reader[3]) == 1)
            item.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);

        else
            item.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
    }


   
    public void BuyProcessing(int cost, string name, GameObject gameObject)
    {
        if(balanceForBuy - cost >= 0)
        {
            connections();
            IDbCommand dbcmd = _connection.CreateCommand();
            string sqlQuery = "UPDATE CoinsTable SET Coins = Coins -" + cost;
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteNonQuery();
           

            dbcmd = _connection.CreateCommand();
            sqlQuery = "UPDATE Shop SET IsLocked = '0' WHERE Name = '" + name + "'";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteNonQuery();
            gameObject.SetActive(false);
            ObjectsList.instance.allObjects[0].SetActive(false);
            _connection.Close();
            Balance();
        }
        else
        {
            Debug.Log("Have no enough money");
        }
        
    }

    public void Balance()
    {
        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "SELECT * FROM CoinsTable";
        dbcmd.CommandText = sqlQuery;
        _reader = dbcmd.ExecuteReader();
        Balance bal = new Balance();


        balanceForBuy = Convert.ToInt32(_reader[0]);
        bal.Bal(_reader[0].ToString());
        _connection.Close();
        
    }

    public void SelectedItem(string shipName)
    {
        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "UPDATE SelectedShip SET ShipName = '" + shipName + "'";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        _connection.Close();
    }



    public void SelectedShipName()
    {
        connections();
        IDbCommand dbcmd = _connection.CreateCommand();
        string sqlQuery = "SELECT * FROM SelectedShip";
        dbcmd.CommandText = sqlQuery;
        _reader = dbcmd.ExecuteReader();
        selectedShipName = _reader[0].ToString();
        _connection.Close();
    }

}

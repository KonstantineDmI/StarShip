using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    public Text testBal;
    void Start()
    {
        ShopDataBase shop = new ShopDataBase();
        shop.Balance();
    }

    public void Bal (string balance)
    {
        GameObject go = ObjectsList.instance.allObjects[1];
        go.GetComponent<Text>().text = balance;
    }

   

    

}

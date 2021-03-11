using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public Text itemText;
    public static int cost;
    public static string name;
    public static  GameObject currentItem;
    public GameObject checkMark;
    public static GameObject selectedItem;
    public void OnClick()
    {
        if(transform.GetChild(2).gameObject.activeSelf == true)
        {
            ObjectsList.instance.allObjects[0].SetActive(true);
            ItemText();
        }
        else
        {
            SelectedItem();
        }
       
    }

    private void Start()
    {
        
    }

    void ItemText()
    {
        Text nameOfShipTxt = this.transform.GetChild(3).GetComponent<Text>();
        Text costTxt = this.transform.GetChild(4).GetComponent<Text>();
        Text mainTextTxt = ObjectsList.instance.allObjects[0].transform.GetChild(0).GetComponent<Text>();
        name = nameOfShipTxt.text;
        cost = Convert.ToInt32(costTxt.text);
        currentItem = this.transform.GetChild(2).gameObject;
        mainTextTxt.text = $"Do you really want to buy <color=red>{nameOfShipTxt.text}</color> for <color=red>{costTxt.text}$ </color>?";
        ObjectsList.instance.allObjects[0].GetComponent<BuyPanelVisible>().SlidersUpdate(nameOfShipTxt.text);


    }

    public void Buy()
    {
        AppStart.shopDB.BuyProcessing(cost, name, currentItem);
    }


    public void SelectedItem()
    {

        ObjectsList.instance.allObjects[3].transform.SetParent(this.gameObject.transform);
        ObjectsList.instance.allObjects[3].transform.position = new Vector3(transform.position.x - 100, this.transform.position.y - 15, this.transform.position.z);


        selectedItem = this.gameObject;

        string shipName = selectedItem.transform.GetChild(3).GetComponent<Text>().text;
        SpawnPlayer.shipName = shipName;
        ShopDataBase shopDB = new ShopDataBase();
        shopDB.SelectedItem(shipName);
    }
}

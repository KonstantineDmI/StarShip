using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanelVisible : MonoBehaviour
{
    GameObject currentShip;
    public Slider damage;
    public Slider health;
    public Slider speed;

    public void SlidersUpdate(string shipName)
    {
        for (int i = 0; i < ShipsList.instance.allShips.Count; i++)
        {
            if (ShipsList.instance.allShips[i].name == shipName)
            {
                currentShip = ShipsList.instance.allShips[i].gameObject;
                break;
            }
        }

        damage.value = currentShip.GetComponent<Player>().bullet.GetComponent<Damage>().bulletDamage;
        health.value = currentShip.GetComponent<Player>().maxHeatlh;
        speed.value = currentShip.GetComponent<Player>().speed;
    }

}

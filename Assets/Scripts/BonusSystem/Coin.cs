using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    [SerializeField]
    private Text _coinValueText;

    [SerializeField]
    private Text _coinsAmount;

    private GameObject _coin;
    private GameObject _coinCountManager;

    private int _coinValue;


    void Start()
    {
        _coinValue = Random.Range(5, 50);
        _coin = GameObjectsList.instance.allObjects[1];
        _coinValueText = _coin.gameObject.transform.GetChild(0).GetComponent<Text>();

        _coinCountManager = GameObjectsList.instance.allObjects[2];
        _coinsAmount = _coinCountManager.gameObject.transform.GetChild(0).GetComponent<Text>();
    }

   
    void Update()
    {
        transform.position -= new Vector3(0, _speed * Time.deltaTime);

        transform.Rotate(new Vector3(45, 45, 0) * _speed *  Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            other.gameObject.GetComponent<Player>().PickCoin();
            _coinValueText.text = "+" + _coinValue;
            DBUpdate.sessionCoinQuantity += _coinValue;
            _coinsAmount.text = DBUpdate.sessionCoinQuantity + "x";
            Destroy(gameObject);
        }
    }

}

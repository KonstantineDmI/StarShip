using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOScript : MonoBehaviour
{
    private GameObject _watchAdvButton;
    private Animator anim;
    void Start()
    {
        _watchAdvButton = gameObject.transform.GetChild(1).gameObject;
        anim = _watchAdvButton.GetComponent<Animator>();
        if(gameObject.activeSelf == true)
        {
            anim.SetBool("isStart", true);
        }
        else
        {
            anim.SetBool("isStart", false);
        }
        
    }

    
  
}

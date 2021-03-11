using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertPanel : MonoBehaviour
{
    public Animator animator;
    
    

    public void Animate(string action)
    {
        this.transform.GetChild(1).GetComponent<Text>().text = action;
        animator = this.GetComponent<Animator>();
        animator.SetBool("IsVisible", true);
    }

    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{

    public void Cancel()
    {
        ObjectsList.instance.allObjects[0].SetActive(false);
    }
}

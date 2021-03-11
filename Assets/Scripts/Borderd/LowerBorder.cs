using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBorder : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Removable>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesList : MonoBehaviour
{
    public static ImagesList instance = null;
    public List<Sprite> allSprites = new List<Sprite>();

    void Awake()
    {

        if (instance == null)
            instance = this;


        else if (instance != this)
            Destroy(gameObject);
    }
}

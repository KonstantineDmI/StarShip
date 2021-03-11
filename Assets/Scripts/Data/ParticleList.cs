using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleList : MonoBehaviour
{

    public static ParticleList instance = null;
    public List<ParticleSystem> allParticles = new List<ParticleSystem>();

    void Awake()
    {
       
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
}

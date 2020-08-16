using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCoin : MonoBehaviour
{
   public ParticleSystem m_particleSystem;

    public float LifeTime;
    float InitTime;
    // Start is called before the first frame update
    void Start()
    {
        InitTime = Time.deltaTime;
        m_particleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>=InitTime+LifeTime)
        {
            Destroy(this);

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField] float TimeBeforeBombExplodes = 0.5f;
    [SerializeField] ParticleSystem Explosion;
    [SerializeField] ParticleSystem SeismicRing;
    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(TimeBeforeBombExplodes);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Instantiate(SeismicRing, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

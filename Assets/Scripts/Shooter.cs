using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float ProjectileSpeed = 10f;
    [SerializeField] float ProjectilelifeSpan = 5f;
    [SerializeField] float BasefiringRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float minimumFireRate = 0.1f;


    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(ProjectilePrefab, 
                                              transform.position, 
                                              Quaternion.identity);

            Rigidbody2D myRigidbody2D = instance.GetComponent<Rigidbody2D>();
            if(myRigidbody2D != null)
            {
                myRigidbody2D.velocity = transform.up * ProjectileSpeed;
            }

            Destroy(instance,ProjectilelifeSpan);
            float TimeToNextProjectile = UnityEngine.Random.Range(BasefiringRate - firingRateVarience,
                                                                  BasefiringRate + firingRateVarience);
            TimeToNextProjectile = Mathf.Clamp(TimeToNextProjectile, minimumFireRate, float.MaxValue);

            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(TimeToNextProjectile);
        }

    }

}

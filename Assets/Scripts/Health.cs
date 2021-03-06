using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem Explosion;
    [SerializeField] ParticleSystem Hit;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            audioPlayer.PlayHitClip();
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void OnParticleCollision(GameObject other) 
    {
        TakeDamage(20);
        audioPlayer.PlayHitClip();
        PlayHitEffect();
        Debug.Log("Particle Hit");
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        audioPlayer.PlayExplosionClip();
        PlayExplosionEffect();
        Destroy(gameObject);
    }

    void PlayHitEffect() 
    {
        if(Hit != null)
        {
            ParticleSystem instance = Instantiate(Hit, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayExplosionEffect() 
    {
        if(Explosion != null)
        {
            ParticleSystem instance = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    public int GetHealth() 
    {
        return health;
    }
}

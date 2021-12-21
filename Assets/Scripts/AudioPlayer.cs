using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("Hit")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] [Range(0f,1f)] float hitVolume = 1f;
    [SerializeField] AudioClip smallExplosionClip;
    [SerializeField] [Range(0f,1f)] float smallExplosionVolume = 0.1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f,1f)] float explosionVolume = 1f;

    static AudioPlayer instance;

    private void Awake() 
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip() 
    {
        if(shootingClip != null )
        {
            AudioSource.PlayClipAtPoint(shootingClip, 
                                        Camera.main.transform.position, 
                                        shootingVolume);  
        }
    }

    public void PlayExplosionClip() 
    {
        if(explosionClip != null)
        {
            AudioSource.PlayClipAtPoint(explosionClip, 
                                        Camera.main.transform.position, 
                                        explosionVolume);
        }
    }

    public void PlayHitClip() 
    {
        if(hitClip != null && smallExplosionClip != null)
        {
            AudioSource.PlayClipAtPoint(hitClip, 
                                        Camera.main.transform.position, 
                                        hitVolume);
            AudioSource.PlayClipAtPoint(smallExplosionClip, 
                                        Camera.main.transform.position, 
                                        smallExplosionVolume);
        }
    }
}

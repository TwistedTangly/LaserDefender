using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigSOs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    
    void Start()
    { 
        StartCoroutine(SpawnEnemyWaves());
    }
    public WaveConfigSO GetCurrentWave() 
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach(WaveConfigSO wave in waveConfigSOs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0,0,180),    
                                transform); //become a child of the enemy spawner to free up the hierachy
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }            
        }          
        while(isLooping);
        
    }
}

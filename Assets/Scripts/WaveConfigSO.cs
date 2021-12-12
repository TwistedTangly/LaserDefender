using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVarience = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint() 
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() 
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() 
    {
        return moveSpeed;
    }

    public int GetEnemyCount() 
    {
        return enemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index) 
    {
        return enemyPrefab[index];
    }

    public float GetRandomSpawnTime() 
    {
        //sets a random number 
        float spawnTime = Random.Range(timeBetweenEnemySpawns- spawnTimeVarience,
                                       timeBetweenEnemySpawns + spawnTimeVarience);
        //clamp the number between the set minimumNumber and the max value a float can hold, so it cannot be negative
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}

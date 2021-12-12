using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfigSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfigSO = enemySpawner.GetCurrentWave();
        waypoints = waveConfigSO.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if(waypointIndex < waypoints.Count)    
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;     //new vector3 of the postition of the current waypoint we want to move towards
            float delta = waveConfigSO.GetMoveSpeed() * Time.deltaTime;     //float of how fast we want the ship to move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);    //move the ship from its current position towars the next way point at the speed we've set
            if(transform.position == targetPosition)    //if the position of the ship and the waypoint are the same add one to the waypoint index, to stat moveing towards the next waypoint
            {
                waypointIndex++;    //increment waypoint index
            }
        }
        else
        {
            Destroy(gameObject);    //if there are no more wypoints destropy the ship
        }
    }
}

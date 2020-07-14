using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] int secondsBetweenSpawn = 2;
    
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        Waypoint startWaypoint = pathfinder.GetStartWaypoint();
        StartCoroutine(Spawning(startWaypoint));
    }

    IEnumerator Spawning(Waypoint startWaypoint)
    {
        while(true)
        {
            Instantiate(enemyPrefab, startWaypoint.transform.position, startWaypoint.transform.rotation );
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] private Transform _enemyTransformLocation;

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
            var _enemy = Instantiate(enemyPrefab, startWaypoint.transform.position, startWaypoint.transform.rotation );
            _enemy.transform.parent = _enemyTransformLocation;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
        
    }
}

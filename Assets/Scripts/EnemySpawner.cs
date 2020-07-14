using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        Waypoint startWaypoint = pathfinder.GetStartWaypoint();
        Instantiate(enemyPrefab, startWaypoint.transform.position, startWaypoint.transform.rotation );
    }
}

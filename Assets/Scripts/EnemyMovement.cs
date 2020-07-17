    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour

{

    [SerializeField] private float _secondsBetweenMovement = 1;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.path;
        StartCoroutine(EnemyMoving(path));
    }

    IEnumerator EnemyMoving(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(_secondsBetweenMovement);
        }

    } 

}

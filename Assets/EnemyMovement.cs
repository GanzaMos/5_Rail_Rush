    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour

{
    
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        StartCoroutine(PrintWayPoint());
        print("O_o");
    }

    IEnumerator PrintWayPoint()
    {
        print("We start movenig");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Now we at a waypoint " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("We end movenig");
    }

}

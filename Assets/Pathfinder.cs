using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> path = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    void Start()
    {
        DictionaryOfBlocks();
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
    }



    private void DictionaryOfBlocks()
    {
        foreach (Waypoint waypoint in FindObjectsOfType<Waypoint>())
        {
            if (path.ContainsKey(waypoint.GetGridPos()))
            {
                print("Duplicate Block in position " + waypoint.GetGridPos());
            }
            else
            {
                path.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print("Number of Blocks - " + path.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

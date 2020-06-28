using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    void Start()
    {
        DictionaryOfBlocks();
        ExploreNeighbours();
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    void ExploreNeighbours ()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                //do nothing
            }
            
        }
    }

    private void DictionaryOfBlocks()
    {
        foreach (Waypoint waypoint in FindObjectsOfType<Waypoint>())
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                print("Duplicate Block in position " + waypoint.GetGridPos());
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print("Number of Blocks - " + grid.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

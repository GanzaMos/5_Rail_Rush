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
        Vector2Int.down,
        Vector2Int.left
    };

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

    void Start()
    {
        DictionaryOfBlocks();
        PathFind();
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            HaltIfReachEnd(searchCenter);
            print("Start search at " + searchCenter);
            searchCenter.isExploring = true;
            ExploreNeighbours(searchCenter);
        }


    }

    private void HaltIfReachEnd(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("We rich the end waypoint");
            isRunning = false;
        }
    }

    void ExploreNeighbours (Waypoint from)
    {
        if (!isRunning) return;

        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = from.GetGridPos() + direction;
            try
            {
                var exploreNeighbour = grid[explorationCoordinates];
                if (!exploreNeighbour.isExploring)
                {
                    exploreNeighbour.SetTopColor(Color.blue);
                    queue.Enqueue(exploreNeighbour);
                    print("Add to queue " + exploreNeighbour.GetGridPos());
                }
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

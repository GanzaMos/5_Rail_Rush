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

    Waypoint searchCenter;

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
            searchCenter = queue.Dequeue();
            HaltIfReachEnd();
            searchCenter.isExploring = true;
            ExploreNeighbours();
        }


    }

    private void HaltIfReachEnd()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    void ExploreNeighbours()
    {
        if (!isRunning) return;

        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                var neighbour = grid[explorationCoordinates];
                if (!neighbour.isExploring || queue.Contains(neighbour))
                {
                    neighbour.SetTopColor(Color.blue);
                    queue.Enqueue(neighbour);
                    neighbour.exploredFromWaypoint = searchCenter;
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
            if (!grid.ContainsKey(waypoint.GetGridPos()))
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}

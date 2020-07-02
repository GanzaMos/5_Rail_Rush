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
    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        DictionaryOfBlocks();
        BreathFirstSearch();
        ColorStartAndEnd();
        CreatePath();
        return path;
    }

    bool isRunning = true;

    Waypoint searchCenter;

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFromWaypoint;

        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFromWaypoint;
        }

        path.Add(startWaypoint);

        path.Reverse();
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void BreathFirstSearch()
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
            if (grid.ContainsKey(explorationCoordinates))
            {
                var neighbour = grid[explorationCoordinates];
                if (!neighbour.isExploring || queue.Contains(neighbour))
                {
                    neighbour.SetTopColor(Color.blue);
                    queue.Enqueue(neighbour);
                    neighbour.exploredFromWaypoint = searchCenter;
                }
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

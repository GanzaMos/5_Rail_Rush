using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExploring = false;

    public Waypoint exploredFromWaypoint;
    
    public enum blockTypeEnum {Enemy, Friendly, Neutral};
    public blockTypeEnum blockType = blockTypeEnum.Enemy;

    [SerializeField] TowerScript tower;
    private bool _towerSet = false;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && blockType == blockTypeEnum.Friendly && _towerSet == false)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            _towerSet = true;
        }
        
    }

}

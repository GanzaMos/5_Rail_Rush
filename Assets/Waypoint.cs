﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    public enum typeOfBlock {Start, End, Regular}
    public typeOfBlock blockType = typeOfBlock.Regular;
    Vector2Int gridPos;
    const int gridSize = 10;

    public void SetTopColor(Color color)
    {
        transform.Find("Top").GetComponent<MeshRenderer>().material.color = color;
    }

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

}

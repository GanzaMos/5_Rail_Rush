using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class SimleEditorScript : MonoBehaviour

{

    const int sizeOfTheGrid = 10;

    void Update()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(
            GetGridPos().x * sizeOfTheGrid,
            0f,
            GetGridPos().y * sizeOfTheGrid
        );
    }

    Vector2Int GetGridPos()
    {
        return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / sizeOfTheGrid),
                Mathf.RoundToInt(transform.position.z / sizeOfTheGrid)
            );
    }

}

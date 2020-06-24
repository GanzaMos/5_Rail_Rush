using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]

public class EditorScript : MonoBehaviour

{
    [Range (1f, 20f)] [Tooltip ("Size of the Grid for Cube Blocks")] [SerializeField] int sizeOfTheGrid = 10;

    TextMesh textMesh;

    void Update()
    {
        GridScript();
        TextMeshScript();
    }

    private void TextMeshScript()
    {
        int coordinateX = Mathf.RoundToInt(transform.position.x / sizeOfTheGrid);
        int coordinateZ = Mathf.RoundToInt(transform.position.z / sizeOfTheGrid);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = Convert.ToString(coordinateX) + ","+ Convert.ToString(coordinateZ);
    }

    private void GridScript()
    {
        Vector3 pos;
        pos.x = Mathf.RoundToInt(transform.position.x / sizeOfTheGrid) * sizeOfTheGrid;
        pos.z = Mathf.RoundToInt(transform.position.z / sizeOfTheGrid) * sizeOfTheGrid;
        pos.y = 0;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}

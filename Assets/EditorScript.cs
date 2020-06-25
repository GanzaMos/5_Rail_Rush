using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]

public class EditorScript : MonoBehaviour

{
    [Range (1f, 20f)] [Tooltip ("Size of the Grid for Cube Blocks")] [SerializeField] int sizeOfTheGrid = 10;

    TextMesh textMesh;
    int coordinateX;
    int coordinateZ;

    void Update()
    {
        GridScript();
        TextMeshScript();
        NamingCube();
    }

    private void GridScript()
    {
        Vector3 pos;
        pos.x = Mathf.RoundToInt(transform.position.x / sizeOfTheGrid) * sizeOfTheGrid;
        pos.z = Mathf.RoundToInt(transform.position.z / sizeOfTheGrid) * sizeOfTheGrid;
        pos.y = 0;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
        private void TextMeshScript()
    {
        coordinateX = Mathf.RoundToInt(transform.position.x / sizeOfTheGrid);
        coordinateZ = Mathf.RoundToInt(transform.position.z / sizeOfTheGrid);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = coordinateX + ","+ coordinateZ;
    }
        private void NamingCube()
    {
        gameObject.name = coordinateX + ","+ coordinateZ;
    }
}

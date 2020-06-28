using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class EditorScript : MonoBehaviour

{
    TextMesh textMesh;
    Waypoint waypoint;

    void Awake() 
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        LabelUpdate();
    }

    private void SnapToGrid()
    {
        int sizeOfTheGrid = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * sizeOfTheGrid,
            0f,
            waypoint.GetGridPos().y * sizeOfTheGrid
        );
    }
        private void LabelUpdate()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x + 
            ","+ 
            waypoint.GetGridPos().y;
        textMesh.text = labelText;

        gameObject.name = labelText;
    }
}

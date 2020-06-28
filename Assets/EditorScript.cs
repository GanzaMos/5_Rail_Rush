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
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y
        );
    }
        private void LabelUpdate()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x / waypoint.GetGridSize() + 
            ","+ 
            waypoint.GetGridPos().y / waypoint.GetGridSize();
        textMesh.text = labelText;

        gameObject.name = labelText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorScript : MonoBehaviour
{
    void Update()
    {
        Vector3 pos;
        pos.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        pos.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        pos.y = 0;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}

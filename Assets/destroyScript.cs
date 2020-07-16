using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyScript : MonoBehaviour
{

    void Start()
    {
        Invoke("destroyClass", 1f);
    }

    private void destroyClass()
    {
        Destroy(gameObject);
    }
}

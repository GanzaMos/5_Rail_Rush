using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    EnemyMovement enemy;

    void Start()
    {
       enemy = FindObjectOfType<EnemyMovement>(); 
    }

    void Update()
    {
        transform.LookAt(enemy.transform);
    }
}

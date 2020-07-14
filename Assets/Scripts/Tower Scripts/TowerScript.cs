﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    EnemyMovement[] enemies;
    [SerializeField] int towerRange = 30;

    void Update()
    {
        enemies = FindObjectsOfType<EnemyMovement>();
        CheckForEnemies();
    }

    private void CheckForEnemies()
    {
        if (enemies.Length > 0)
        {
            SearchForClosestEnemy();
        }
        else
        {
            ParticlesEnableStatus(false);
        }
    }

    private void SearchForClosestEnemy()
    {
        float minDistance = 1000f;
        EnemyMovement closestEnemy = enemies[0];

        foreach (var currentEnemy in enemies)
        {
            float distance = Vector3.Distance(gameObject.transform.position, currentEnemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = currentEnemy;
            }
        }
        
        if (Vector3.Distance(gameObject.transform.position, closestEnemy.transform.position) < towerRange)
        {
            ParticlesEnableStatus(true);
            GetComponentInChildren<LookAtTheEnemy>().LookAtTheEnemyMethod(closestEnemy.transform);
        }
        else
        {
            ParticlesEnableStatus(false);
        }
    }

    private void ParticlesEnableStatus(bool toggle)
    {
        foreach (Transform transform in transform.GetComponentsInChildren<Transform>(true))
        {
            if (transform.GetComponent<ParticleSystem>() == true)
            {
                transform.gameObject.SetActive(toggle);
            }
        }
    }
}

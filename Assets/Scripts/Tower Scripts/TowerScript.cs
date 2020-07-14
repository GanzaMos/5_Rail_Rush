using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    EnemyMovement enemy;
    [SerializeField] int towerRange = 30;

    void Start()
    {
        enemy = FindObjectOfType<EnemyMovement>();
    }

    void Update()
    {
        if(enemy) {LookAndFire();}
        else {ParticlesEnableStatus(false);}
    }

    private void LookAndFire()
    {
        Vector3 distance = gameObject.transform.position - enemy.transform.position;

        if (enemy && distance.magnitude < towerRange)
        {
            ParticlesEnableStatus(true);
            GetComponentInChildren<LookAtTheEnemy>().LookAtTheEnemyMethod(enemy.transform);
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

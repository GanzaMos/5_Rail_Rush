    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour

{

    [SerializeField] private float _secondsBetweenMovement = 1;
    [SerializeField] private ParticleSystem _deathEffect;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.path;
        StartCoroutine(EnemyMoving(path));
    }

    IEnumerator EnemyMoving(List<Waypoint> path)
    {    
        
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(_secondsBetweenMovement);
        }
        DeathEffect();
        Destroy(gameObject);
    }

    private void DeathEffect()
    {
        var deathVFX = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        deathVFX.transform.parent = this.transform.parent;
        Destroy(deathVFX, deathVFX.main.duration);
    }
}

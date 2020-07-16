using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private ParticleSystem deathParticle;
    void Update()
    {
    
    }

    void OnParticleCollision(GameObject other) 
    {
        hitPoints -= 1;
        hitParticle.Play();
        
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
    }
}

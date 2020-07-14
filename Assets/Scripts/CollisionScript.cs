using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    void Update()
    {
    
    }

    void OnParticleCollision(GameObject other) 
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}

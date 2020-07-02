using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    void Update()
    {
    
    }

    void OnParticleCollision(GameObject other) 
    {
        print("Collision happens");
    }
}

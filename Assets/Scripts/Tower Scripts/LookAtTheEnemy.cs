using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTheEnemy : MonoBehaviour
{
    public void LookAtTheEnemyMethod(Transform enemy)
    {
        transform.LookAt(enemy);
    }
}

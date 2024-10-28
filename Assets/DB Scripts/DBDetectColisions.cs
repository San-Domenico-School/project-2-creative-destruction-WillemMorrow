using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of Projectiles
 * Detects Collisions
 * 
 * Version1
 * Pacifica Morrow
 * 10.22.2024
 * **************************/

public class DBDetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("projectile"))
        {
           
            Destroy(gameObject);
        }

        if (CompareTag("ally"))
        {
            Destroy(other.gameObject);
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}

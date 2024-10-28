using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of Animals
 * Detects Collisions
 * 
 * Version1
 * Pacifica Morrow
 * 10.11.2024
 * **************************/

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

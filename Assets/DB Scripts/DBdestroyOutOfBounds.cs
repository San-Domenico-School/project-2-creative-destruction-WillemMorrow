using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of Projectiles and Disk
 * Destroys Projectiles on the borders
 * 
 * Version1
 * Pacifica Morrow
 * 10.22.2024
 * **************************/

public class DBdestroyOutOfBounds : MonoBehaviour
{
    private float upperBoundZ = 30.0f;
    private float lowerBoundZ = -5.0f;
    private float upperBoundX = 10.0f;
    private float lowerBoundX = -100.0f;

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        
        if (transform.position.x > upperBoundX)
        {
            if (CompareTag("disk"))
            {
                Destroy(gameObject);
            }

            if (CompareTag("projectile"))
            {
                Debug.Log("GameOver");
                Destroy(gameObject);
            }

            if (CompareTag("ally"))
            {
                Debug.Log("Transport is through the shield.");
                Destroy(gameObject);
            }
        }

        if (transform.position.x < lowerBoundX)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > upperBoundZ)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < lowerBoundZ)
        {
            Destroy(gameObject);
        }
    }
}

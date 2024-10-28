using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of Animals and Food
 * Destroys Animals on the borders
 * 
 * Version1
 * Pacifica Morrow
 * 10.11.2024
 * **************************/

public class DestroyOutOfScene : MonoBehaviour
{
    private float upperBound = 30.0f;
    private float lowerBound = -5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        
        if (transform.position.z > upperBound)
        {
            Destroy(gameObject);
        }

        

        if (transform.position.z < lowerBound)
        {
            if (CompareTag("food"))
            {
                Destroy(gameObject);
            }

            if (CompareTag("animal"))
            {
                Debug.Log("GameOver");
                Destroy(gameObject);
                
            }

            if (CompareTag("animal"))
            {
                Debug.Log("Ally Through");
                Destroy(gameObject);
            }
        }
    }
}

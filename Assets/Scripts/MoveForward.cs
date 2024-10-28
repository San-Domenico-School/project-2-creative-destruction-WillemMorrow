using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of Animals and Food
 * Controles Animal Movement
 * 
 * Version1
 * Pacifica Morrow
 * 10.09.2024
 * **************************/

public class MoveForward : MonoBehaviour
{

    [Range(1, 30)][SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

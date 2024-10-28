using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of SpawnManager
 * Manages animal spawns
 * 
 * Version1
 * Pacifica Morrow
 * 10.11.2024
 * **************************/

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 17f;                        //distance from centre of field
    private float startDelay = 2.0f;                       //time before first spawn
    private float spawnInterval = 1.5f;                    //interval between spawns
    [SerializeField] private GameObject[] animals;         //list of every animal to spawn

    // Calls the SpawnRandomAnimal method after a certain delay, then every time interval.
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Spawns a random animal in a random place from centre.
    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0.0f, 25.0f);
        GameObject animal = animals[animalIndex];

        Instantiate(animal, spawnPosition, animal.transform.rotation);
    }
}

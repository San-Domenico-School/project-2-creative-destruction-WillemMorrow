using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****************************
 * Component of SpawnManager
 * Manages animal spawns
 * 
 * Version1
 * Pacifica Morrow
 * 10.22.2024
 * **************************/

public class DBspawnManager : MonoBehaviour
{
    private float spawnRangeLower = 0.0f;                   //Lower binding of where the Projectiles can spawn
    private float spawnRangeUpper = 15.0f;                  //upper binding of where the Projectiles can spawn
    private float startDelay = 2.0f;                        //time before first spawn
    [SerializeField] private float spawnInterval;           //interval between spawns
    [SerializeField] private GameObject[] projectiles;      //list of every projectile to spawn

    // Calls the SpawnRandomAnimal method after a certain delay, then every time interval.
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Spawns a random animal in a random place from centre.
    private void SpawnRandomAnimal()
    {
        int projectileIndex = Random.Range(0, projectiles.Length);
        Vector3 spawnPosition = new Vector3(-80.0f, Random.Range(spawnRangeLower, spawnRangeUpper), Random.Range(spawnRangeLower, spawnRangeUpper));
        GameObject projectile = projectiles[projectileIndex];

        Instantiate(projectile, spawnPosition, projectile.transform.rotation);
    }
}

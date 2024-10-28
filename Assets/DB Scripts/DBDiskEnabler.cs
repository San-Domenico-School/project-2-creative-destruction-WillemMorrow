using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************************
 * script which disables the disk's meshrenderer component after it is instantiated
 * 
 * component of the disk prefab
 * 
 * 10.28.2024
 * Pacifica Morrow
 * ******************************/

public class DBDiskEnabler : MonoBehaviour
{
    private MeshRenderer diskRenderer;                //reference to the object's meshrenderer component
    private float projectileVisualDelay = 0.1f;       //the time, in seconds before the projectile appears

    //gets the meshrenderer component, sets it to false.
    private void Awake()
    {
        diskRenderer = GetComponent<MeshRenderer>();
        diskRenderer.enabled = false;
    }

    // calls the Projectile Enabler function following Awake
    void Start()
    {
        StartCoroutine("ProjectileEnabler");
    }

    //enables the meshrenderer after a delay
    IEnumerator ProjectileEnabler()
    {
        //Debug.Log("DiskEnablerWorking(?)");
        yield return new WaitForSeconds(projectileVisualDelay);
        diskRenderer.enabled = true;
    }
}

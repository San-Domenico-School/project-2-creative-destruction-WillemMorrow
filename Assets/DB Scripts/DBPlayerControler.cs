using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************
 * Player control for project 2; Defence Battery
 * component of Player
 * 
 * Version 1
 * Pacifica Morrow
 * 10.30.2024
 * **************************/

public class DBPlayerControler : MonoBehaviour
{
    //Camera-related fields
    [SerializeField] private float cameraSensitivity;
    private Camera mainCamera;

    //projectile related feilds
    [SerializeField] private GameObject projectile;
    [SerializeField] private float coolDownTime;
    private bool coolDownActive;
    [SerializeField] private float projectileVisualDelay;

    private float verticalRotation = 0.0f;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        //Controls camera movement
        float MouseX = Input.GetAxis("Mouse X") * cameraSensitivity;    //ASK MR GUSTIN HOW THIS WORKS WHEN AVAILABLE
        float MouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;

        verticalRotation -= MouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * MouseX);
    }

    private void OnFire(InputValue Input)
    {
        if (coolDownActive == false)            //only executes food firing if off cooldown
        {
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, mainCamera.transform.rotation);
            }
            else
            {
                Debug.LogWarning("Projectile reference is missing!");
            }
            coolDownActive = true;
            StartCoroutine("ActiveCooldown");
        }

    }

    IEnumerator ActiveCooldown()
    {
        //execute before wait
        yield return new WaitForSeconds(coolDownTime);        //waits for the cooldown before continuing
        //exectues after wait
        coolDownActive = false;
    }

    /*IEnumerator DiskMeshRenderer()
    {
        //execute before wait
        Instantiate(projectile, transform.position, mainCamera.transform.rotation);
        Debug.Log(projectile.gameObject.name);
        projectile.SetActive(false);
        yield return new WaitForSeconds(projectileVisualDelay);        //waits for the cooldown before continuing
        //exectues after wait
        projectile.SetActive(true);
    } */
}

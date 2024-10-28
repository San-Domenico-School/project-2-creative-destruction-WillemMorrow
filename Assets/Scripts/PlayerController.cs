using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/****************************
 * Component of Player
 * Controles Player
 * 
 * Version1
 * Pacifica Morrow
 * 10.09.2024
 * **************************/

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject projectile;     //gets reference for the food projectile prefab
    [SerializeField] private float speed;               //movespeed of the player
    private float centerToEdge;                         //distance player can move from the centerline
    private float moveInput;                            //input to make player move; A/D
    private bool coolDownActive;                        //prevents firing of food if true
    private float coolDownTime = 0.5f;                  //cooldown before food can be fired again

    // Start is called before the first frame update
    private void Start()
    {
        centerToEdge = 17;
    }

    // Calls PlayerMovement every frame.
    private void Update()
    {
        PlayerMovement();
    }

    //handles movement of the player; moves left & right, restricts player to inbounds.
    private void PlayerMovement()
    {
        transform.Translate(Vector2.right * speed * moveInput * Time.deltaTime);
        if (transform.position.x > centerToEdge)
        {
            transform.position = new Vector3(centerToEdge, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -(centerToEdge))
        {
            transform.position = new Vector3(-centerToEdge, transform.position.y, transform.position.z);
        }
    }

    //assigns field 'move' a Vector2 value consisting only of X axis: A/D.
    private void OnMove(InputValue Input)
    {
        Vector2 inputVector = Input.Get<Vector2>();
        moveInput = inputVector.x;
    }

    //instantiates a projectile when 'Fire' input bind is pressed.
    private void OnFire(InputValue Input)
    {
        if (coolDownActive == false)            //only executes food firing if off cooldown
        {
            if (projectile != null)
            {
                Instantiate(projectile, transform.position + Vector3.up, projectile.transform.rotation);
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

}

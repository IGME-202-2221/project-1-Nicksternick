using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Purpose: Vehicle controller for player input
/// </summary>
public class Vehicle : MonoBehaviour
{
    public float speed = 1f;

    public Vector2 direction = Vector2.right;
    public Vector2 velocity = Vector2.zero;

    private Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = movementInput;

        // Update Veclocity
        // Velocity is direction,
        // multiplied by speed
        velocity = direction * speed * Time.deltaTime;

        // Check to see if the Velocity will bring the character out of bounds
        //if (velocity.x > 8 || velocity.x < -8)
        //{
        //    velocity = new Vector2(0, 0);
        //}

        //if (velocity.y > 5 || velocity.y < -5)
        //{
        //    velocity = new Vector2(0, 0);
        //}

        // add out velocities to out positions
        transform.position += (Vector3)velocity;

        //if(direction != Vector2.zero)
        //{
        //    // add rotation
        //    transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        //}

    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }
}

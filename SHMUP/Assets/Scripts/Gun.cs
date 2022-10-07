using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public SpriteInfo sprite;

    public bool input;
    public bool prevInput;
    int i = 0;

    public GameObject bulletPrefab;

    public Vector2 direction = Vector2.up;
    //public Vector2 velocity = Vector2.zero;

    private Vector2 movementInput;

    public Vector3 bulletSpawnLocation;
    float bulletX;
    float bulletY;

    // Start is called before the first frame update
    void Start()
    {
        prevInput = false;
        input = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementInput != Vector2.zero)
        {
            direction = movementInput;
            // add rotation
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        if (input && !prevInput)
        {
            SpawnBullet();
        }

        prevInput = input;
    }

    public void SpawnBullet()
    {
        bulletX = 0;
        bulletY = 0;

        if (direction.x > 0)
        {
            bulletX = sprite.MaxX;
        }
        else if (direction.x < 0)
        {
            bulletX = sprite.MinX;
        }

        if (direction.y > 0)
        {
            bulletY = sprite.MaxY;
        }
        else if (direction.y < 0)
        {
            bulletY = sprite.MinY;
        }

        if (bulletX != 0 && bulletY != 0)
        {
            bulletX /= 2;
            bulletY /= 2;
        }

        bulletSpawnLocation = new Vector3(bulletX, bulletY, 0);
        Instantiate(bulletPrefab, bulletSpawnLocation, Quaternion.identity);
    }

    public void Shoot(InputAction.CallbackContext moveContext)
    {
        if (moveContext.performed)
        {
            input = true;
        }
        else
        {
            input = false;
        }
    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        movementInput = moveContext.ReadValue<Vector2>();
    }
}

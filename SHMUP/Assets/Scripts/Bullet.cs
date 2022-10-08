using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    private Vector2 position;
    private int screenX;
    private int screenY;

    public float speed;

    private int wrapCount;

    // ----- | Properties | -----
    public int WrapCount
    {
        get { return wrapCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 4);
        screenX = 8;
        screenY = 5;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position += new Vector2(speed, speed) * direction *Time.deltaTime;

        if (transform.position.x < (screenX * -1))
        {
            position.x = screenX;
            wrapCount++;
        }
        else if (transform.position.x > screenX)
        {
            position.x = screenX * -1;
            wrapCount++;
        }

        if (transform.position.y < (screenY * -1))
        {
            position.y = screenY;
            wrapCount++;
        }
        else if (transform.position.y > screenY)
        {
            position.y = screenY * -1;
            wrapCount++;
        }

        transform.position = position;
    }

    public void GetDirection(Vector2 input)
    {
        direction = input;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}

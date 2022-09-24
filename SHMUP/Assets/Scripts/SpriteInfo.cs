using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Author: Nicholas DiGiovanni
/// Purpose: Holds information about the sprite, to make code simpler
/// </summary>
public class SpriteInfo : MonoBehaviour
{
    // ----- | Variables | -----

    // Variables to keep values of the minimum and maximum bounds
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private Vector3 size;

    private float centerX;
    private float centerY;
    private Vector3 center;

    // Variable to keep the radius based on the bounds
    private float radius;

    // ----- | Properties | -----

    // Properties that are to be acessed by other partnered scripts
    public float MinX
    {
        get { return minX; }
    }
    public float MaxX
    {
        get { return maxX; }
    }
    public float MinY
    {
        get { return minY; }
    }
    public float MaxY
    {
        get { return maxY; }
    }
    public Vector3 Size
    {
        get { return size; }
    }
    public float CenterX
    {
        get { return centerX; }
    }
    public float CenterY
    {
        get { return centerY; }
    }
    public Vector3 Center
    {
        get { return center; }
    }
    public float Radius
    {
        get { return radius; }
    }
    public Color Color
    {
        set
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().color = value;
        }
    }

    // ----- | Methods | -----

    // Start is called before the first frame update
    void Start()
    {
        // set values on start
        minX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.min.x;
        maxX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.max.x;
        minY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.min.y;
        maxY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.max.y;

        size = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size;

        centerX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center.x;
        centerY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center.y;

        center = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center;

        radius = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        //set values on every frame
        minX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.min.x;
        maxX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.max.x;
        minY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.min.y;
        maxY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.max.y;

        centerX = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center.x;
        centerY = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center.y;

        center = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.center;

        //radius = this.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.extents.magnitude;
    }
}

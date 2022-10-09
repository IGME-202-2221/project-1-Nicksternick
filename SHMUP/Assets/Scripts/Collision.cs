using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Collision : MonoBehaviour
{
    // ----- | Variables | -----
    public Gun playerGun;
    public SpriteInfo player;
    public List<SpriteInfo> collidable = new List<SpriteInfo>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // For player colliding with anything
        for (int i = 0; i < collidable.Count; i++)
        {
            if (AABBCollision(player, collidable[i]))
            {
                player.Color = Color.red;
                break;
            }
            else
            {
                player.Color = Color.white;
            }
        }

        for (int i = 0; i < playerGun.playerBullets.Count; i++)
        {
            if (AABBCollision(player, playerGun.playerBullets[i].SpriteInfo))
            {
                player.Color = Color.red;
                break;
            }
            else
            {
                player.Color = Color.white;
            }
        }

        // Check for player bullets colliding with enemy
        for (int i = 0; i < collidable.Count; i++)
        {
            // if it's an ememy, check for anything colliding it
            if (collidable[i].Tag == "Enemy")
            {
                if(playerGun.playerBullets.Count > 0)
                {
                    // Loop through player bullets
                    for (int j = 0; j < playerGun.playerBullets.Count; j++)
                    {
                        if (AABBCollision(collidable[i], playerGun.playerBullets[j].SpriteInfo))
                        {
                            collidable[i].Color = Color.blue;
                            break;
                        }
                        else
                        {
                            collidable[i].Color = Color.white;
                        }
                    }
                }
            }
        }
    }

    private bool AABBCollision(SpriteInfo player, SpriteInfo collidable)
    {
        // Check using AABB collision
        if (player.MinY < collidable.MaxY &&
            player.MaxY > collidable.MinY)
        {
            if (player.MinX < collidable.MaxX &&
                player.MaxX > collidable.MinX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

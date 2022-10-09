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
    public List<Enemy> collidable = new List<Enemy>();

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
            if (AABBCollision(player, collidable[i].SpriteInfo))
            {
                player.Color = Color.red;
                Debug.Log("Enemy!");
                break;
            }
            else
            {
                player.Color = Color.white;
            }
        }

        if(playerGun.playerBullets.Count > 0)
        {
            for (int i = 0; i < playerGun.playerBullets.Count; i++)
            {
                if (playerGun.playerBullets[i].SpriteInfo != null)
                {
                    if (AABBCollision(player, playerGun.playerBullets[i].SpriteInfo))
                    {
                        player.Color = Color.red;
                        Debug.Log("Bullet!");
                        break;
                    }
                    else
                    {
                        player.Color = Color.white;
                    }
                }
            }
        }


        // Check for player bullets colliding with enemy
        for (int i = 0; i < collidable.Count; i++)
        {
            if (collidable[i].SpriteInfo != null)
            {
                // if it's an ememy, check for anything colliding it
                if (collidable[i].SpriteInfo.Tag == "Enemy")
                {
                    if (playerGun.playerBullets.Count > 0)
                    {
                        // Loop through player bullets
                        for (int j = 0; j < playerGun.playerBullets.Count; j++)
                        {
                            if (playerGun.playerBullets[j].SpriteInfo != null)
                            {
                                if (AABBCollision(collidable[i].SpriteInfo, playerGun.playerBullets[j].SpriteInfo))
                                {
                                    collidable[i].SpriteInfo.Color = Color.blue;

                                    // Spawn in new enemeies and destroy the original
                                    collidable[i].OnHit();
                                    collidable[i].AddEnemiesToList(collidable);
                                    collidable[i].Kill();
                                    collidable.RemoveAt(i);

                                    // Destroy the bullet that caused the collision
                                    playerGun.playerBullets[j].Kill();
                                    playerGun.playerBullets.RemoveAt(j);

                                    break;
                                }
                                else
                                {
                                    collidable[i].SpriteInfo.Color = Color.white;
                                }
                            }
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

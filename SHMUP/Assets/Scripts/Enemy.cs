using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ----- | Variables | -----
    private SpriteInfo spriteInfo;

    // variables for movement
    public float speed;
    public Vector3 targetLocation;
    public Vector3 position;
    public Vector3 direction;

    public float x;
    public float y;

    // Used to spawn the recursive enemies
    public List<Enemy> newEnemies = new List<Enemy>();
    public int iteration;
    private Vector2 spawnDirection;
    public Enemy prefab;
    public Vector3 spawnLocation;
    public Vector3 scaleVector;

    // ----- | Properties | -----
    public SpriteInfo SpriteInfo
    {
        get { return spriteInfo; }
        set { spriteInfo = value; }
    }

    public int Iteration
    {
        get { return iteration; }
        set { iteration = value; }
    }

    public Enemy Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    public List<Enemy> NewEnemies
    {
        get { return newEnemies; }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 6);
        spriteInfo = gameObject.GetComponent<SpriteInfo>();
        GetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        position = gameObject.transform.position;

        direction = targetLocation - position;

        direction.Normalize();

        position.x += speed * direction.x * Time.deltaTime;
        position.y += speed * direction.y * Time.deltaTime;
        position.z = 0;

        gameObject.transform.position = position;

        if (gameObject.transform.position.x > targetLocation.x - .5 &&
            gameObject.transform.position.x < targetLocation.x + .5)
        {
            if (gameObject.transform.position.y > targetLocation.y - .5 &&
            gameObject.transform.position.y < targetLocation.y + .5)
            {
                GetTargetPosition();
            }
        }


    }

    public void GetTargetPosition()
    {
        targetLocation = new Vector3(Random.Range(-8, 8), Random.Range(-5, 5), 0);
    }

    public void AddEnemiesToList(List<Enemy> enemyList)
    {
        foreach (Enemy enemy in newEnemies)
        {
            enemyList.Add(enemy);
        }
    }

    // Run this method if a collision is detected
    public void OnHit()
    {
        if (iteration < 4)
        {
            for (int i = 0; i < 2; i++)
            {
                newEnemies.Add(Instantiate(prefab, spriteInfo.Center, Quaternion.identity));
                newEnemies[newEnemies.Count - 1].Iteration = iteration + 1;
                newEnemies[newEnemies.Count - 1].Prefab = prefab;
                newEnemies[newEnemies.Count - 1].HalfSize();
            }
        }
        else
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    public void HalfSize()
    {
        gameObject.transform.localScale /= 2;
    }
}

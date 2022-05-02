using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnObstacle[] spawnObstacles;
    public int probabilityObs = 5;
    public int probabilityBoo = 5;
    private int[] obstacles;
    private int[] boosters;
    public float spawnRate = 0.5f;

    private void Start()
    {
        //InvokeRepeating("WhoSpawn", 1f, spawnRate);
        Invoke("WhoSpawn", 0.2f);
    }

    void WhoSpawn()
    {
        int countObs = 0;
        int countBoo = 0;
        obstacles = new int[spawnObstacles.Length];
        boosters = new int[spawnObstacles.Length];


        for (int i = 0; i < spawnObstacles.Length; i++)
        {
            int temp = Random.Range(0, probabilityObs);
            int temp2 = Random.Range(0, probabilityBoo);
            if (temp == 0)
            {
                obstacles[i] = 1;
                countObs++;
            }
            else
            {
                obstacles[i] = 0;
            }
            if (temp2 == 0)
            {
                boosters[i] = 1;
                countBoo++;
            }
            else
            {
                boosters[i] = 0;
            }
        }

        if(countObs == spawnObstacles.Length)
        {
            int remove = Random.Range(0, spawnObstacles.Length);
            obstacles[remove] = 0;
        }
           
        
        for (int i = 0; i < spawnObstacles.Length; i++)
        {
            if(obstacles[i] == 1)
            {
                spawnObstacles[i].SpawnObs();
            }
            if(boosters[i] == 1 && obstacles[i] == 0)
            {
                spawnObstacles[i].SpawnBooster();
            } else if (boosters[i] == 1 && obstacles[i] == 1)
            {
                List<int> empty = new List<int>();
                for (int j = 0; j < spawnObstacles.Length; j++)
                {
                    if(obstacles[j] == 0)
                    {
                        empty.Add(j);
                    }
                }
                int random = Random.Range(0, empty.Count);
                spawnObstacles[empty[random]].SpawnBooster();
            }
        }

        for (int i = 0; i < spawnObstacles.Length; i++)
        {
            obstacles[i] = 0;
            boosters[i] = 0;
        }

        if(spawnRate > 0.6)
            spawnRate -= 0.125f;

        Invoke("WhoSpawn", spawnRate);
    }

    public void IncreaseSpawning()
    {
        if (probabilityObs > 2)
        {
            probabilityObs -= 1;
        }
    }
}

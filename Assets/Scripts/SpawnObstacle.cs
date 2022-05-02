using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject booster;

    public void Start()
    {
        //InvokeRepeating("SpawnObs", 1f, 0.5f);
    }

    public void SpawnObs()
    {
        //int temp = Random.Range(0, 6);
        //if (temp == 0)
        //{
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        //}
    }

    public void SpawnBooster()
    {
        Instantiate(booster, transform.position, Quaternion.identity);
    }
}

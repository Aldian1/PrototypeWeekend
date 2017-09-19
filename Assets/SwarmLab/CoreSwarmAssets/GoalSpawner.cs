using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject smallSwarmUnit, bigSwarmUnit;

    private float lastSpawnSmall;
    private float lastSpawnLarge;
    [SerializeField]
    private float smallUnitsCount;
    [SerializeField]
    private float bigUnitsCount;
    [SerializeField]
    private float spawnLag;
    // Use this for initialization
    void Update()
    {
       
        if(smallUnitsCount > 0 && Time.time > lastSpawnSmall + spawnLag)
        {
            smallUnitsCount--;
            SpawnSmallSwarmUnit();
            lastSpawnSmall = Time.time;
        }

        if (bigUnitsCount > 0 && Time.time > lastSpawnLarge + spawnLag)
        {
            bigUnitsCount--;
            SpawnBigSwarmUnit();
            lastSpawnLarge = Time.time;
        }

    }
    private void SpawnSmallSwarmUnit()
    {
        GameObject swarmCopy = Instantiate(smallSwarmUnit, transform.position, Quaternion.identity);
    }
    private void SpawnBigSwarmUnit()
    {
        GameObject swarmCopy = Instantiate(bigSwarmUnit, transform.position, Quaternion.identity);
    }
}

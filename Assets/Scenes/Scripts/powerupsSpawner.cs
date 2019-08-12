using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupsSpawner : MonoBehaviour
{
    public Transform[] powerupsSpawnPoints;
    public float powerupsSpawnTimer;
    public float powerupsSpawnTimeInterval;
    public GameObject[] powerup;
    public Vector3 endPoint4Pwrups;

    public void spawnPowerups()
    {
        int RandNum4Pos = Random.Range(0, 5);
        int RandNum4Power = Random.Range(0, 3);

        for (int i = 0; i < powerupsSpawnPoints.Length; i++)
        {
            if (RandNum4Pos == i)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (RandNum4Power == j)
                    {
                        GameObject powerupInst = Instantiate(powerup[j], powerupsSpawnPoints[i].position, Quaternion.identity) as GameObject;
                        
                    }
                }
            }
        }
    }

    public void Update()
    {
        if(Time.timeSinceLevelLoad > powerupsSpawnTimer)
        {
            spawnPowerups();
            powerupsSpawnTimer = Time.timeSinceLevelLoad + powerupsSpawnTimeInterval;
        }
    }
}

using UnityEngine;

public class powerupsSpawner : MonoBehaviour
{
    public Transform[] powerupsSpawnPoints;     //array of locations to spawn the powerups
    public float powerupsSpawnTimer;            //time when powerup must be started
    public float powerupsSpawnTimeInterval;     //time between each powerup
    public GameObject[] powerup;                //powerup types in array
    public float speed;                         //speed at which the powerup moves

    public void spawnPowerups()
    {
        int RandNum4Pos = Random.Range(0, 5);   //sets range of spawn points
        int RandNum4Power = Random.Range(0, 3); //sets range of the powerups
        //although, here range is larger, this helps in more randomness of powerup spawn

        for (int i = 0; i < powerupsSpawnPoints.Length; i++)
        {
            if (RandNum4Pos == i)   //if the randomnumber is equal to location
            {
                for (int j = 0; j < 2; j++)     
                {
                    if (RandNum4Power == j)     //if the randomnumber is equal to the powerup
                    {
                        GameObject powerupInst = Instantiate(powerup[j], powerupsSpawnPoints[i].position, Quaternion.identity) as GameObject;
                        powerupInst.GetComponent<Rigidbody>().velocity = Vector3.forward * -speed ;
                        //just spawn the powerup and move it at a speed
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
            //just call the spawner when the time comes to spawn
            //increment the timer when spawn is called
        }
    }
}

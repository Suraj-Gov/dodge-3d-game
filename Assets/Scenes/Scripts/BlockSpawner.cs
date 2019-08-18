using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;         //spawnPoints are location vector stored in array
    public GameObject obstacle;             //gameObjects to spawn in the locations
    public float spawnTime = 2f;            //time to spawn when level is first loaded
    public float timeBetweenSpawns = 1f;        //time between each wave of spawn
    public float thrustSpeed = 5000f;           //speed at which the obstacles proceed towards the player
    

    public void spawnNow()
    {
        int RandNum = Random.Range(0, spawnPoints.Length);
        //gets a random number from the range specified by the length of the array
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(RandNum != i)
                //in a for loop, the objects are spawned with the order of the incrementor,
                //when the incrementor encounters the random number generated,
                //it doesn't spawn an obstacle at that place.
                //cool
            {
                GameObject obstInst = Instantiate(obstacle, spawnPoints[i].position, Quaternion.identity) as GameObject;             
                obstInst.GetComponent<Rigidbody>().AddForce(0, 0, -thrustSpeed,ForceMode.VelocityChange);
                //instantiates obstacle at the spawnPoint position,
                //and then is forced a set force to move towards player
            }
        }   
    }

    public void FixedUpdate()
    {
        //in the fixed update, the code checks if the time passed is equal to time when need to spawn
        //then it spawns
        //after spawn, the timer goal is incremented by timeBetweenSpawns
        if(Time.timeSinceLevelLoad > spawnTime)
        {
            spawnNow();
            spawnTime = Time.timeSinceLevelLoad + timeBetweenSpawns;
            if(timeBetweenSpawns > 0.7f)
            {
                timeBetweenSpawns -= 0.01f;
            }
            else if(timeBetweenSpawns > 0.5f)
            {
                timeBetweenSpawns -= 0.005f;
            }
            else if(timeBetweenSpawns > 0.4f)
            {
                timeBetweenSpawns -= 0.003f;
            }
            

        }

    }

    
}

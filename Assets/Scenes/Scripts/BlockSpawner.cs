using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstacle;
    public float spawnTime = 2f;
    public float timeBetweenSpawns = 1f;
    public float thrustSpeed = 5000f;
    public GameObject univObst;
    

    public void spawnNow()
    {
        int RandNum = Random.Range(0, spawnPoints.Length);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(RandNum != i)
            {


                GameObject obstInst = Instantiate(obstacle, spawnPoints[i].position, Quaternion.identity) as GameObject;
                univObst = obstInst;
                obstInst.GetComponent<Rigidbody>().AddForce(0, 0, -thrustSpeed,ForceMode.VelocityChange);
                
            }
        }   //timeBetweenSpawns = timeBetweenSpawns - timeBetweenSpawns * difficultyMultiplier;
    }

    public void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad > spawnTime)
        {
            spawnNow();
            spawnTime = Time.timeSinceLevelLoad + timeBetweenSpawns;
            // - Time.timeSinceLevelLoad * 0.01f;
            //could add this to gradually increase difficulty, but it's too tough when score passes 50

        }

    }

    
}

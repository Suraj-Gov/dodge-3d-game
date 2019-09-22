using UnityEngine;
using UnityEngine.UI;

public class playerPrefsManager : MonoBehaviour
{
    public Slider moveSpeed;
    public Slider spawnTimeInterval;

    public void Awake()
    {
        spawnTimeInterval.value = PlayerPrefs.GetFloat("spawnTimeIntervalValue", 1.9f);
        moveSpeed.value = PlayerPrefs.GetFloat("moveSpeed", 150f);
    }


    public void adjustSpeed(float speed)
    {
        PlayerPrefs.SetFloat("moveSpeed", speed);
        
    }

    public void adjustSpawntime(float spawnTime)
    {
        PlayerPrefs.SetFloat("spawnTimeIntervalValue", spawnTime);

    }
    

   

}

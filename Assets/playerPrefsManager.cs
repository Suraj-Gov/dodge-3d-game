using UnityEngine;
using UnityEngine.UI;

public class playerPrefsManager : MonoBehaviour
{
    public Slider moveSpeed;
    public Slider spawnTimeInterval;
    public void adjustSpeed(float speed)
    {
        PlayerPrefs.SetFloat("moveSpeed", speed);Debug.Log("This works");
        moveSpeed.value = speed;
    }

    public void adjustSpawntime(float spawnTime)
    {
        PlayerPrefs.SetFloat("spawnTimeInterval", spawnTime);
        spawnTimeInterval.value = spawnTime;
    }

}

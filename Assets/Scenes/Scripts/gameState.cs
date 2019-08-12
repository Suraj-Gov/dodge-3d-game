using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class gameState : MonoBehaviour
{
    public float scaleSlowmo = 10f;
    public float slowmoDuration = 10f;
    
    

    
    public void endGame()
    {

        StartCoroutine(RestartLevel());
        
    }

    

    

  

    IEnumerator RestartLevel()
    {
        
        Time.timeScale = 1f / scaleSlowmo;
        Time.fixedDeltaTime = Time.fixedDeltaTime / scaleSlowmo;

        //yield return new WaitForSeconds(2f / scaleSlowmo);
        //FindObjectOfType<scoreUpdater>().endMessage();

        yield return new WaitForSeconds(slowmoDuration / scaleSlowmo);

        
        Time.timeScale = Time.timeScale * scaleSlowmo;
        Time.fixedDeltaTime = Time.fixedDeltaTime * scaleSlowmo;
        

        SceneManager.LoadScene("MainLevel01");
       
    }

    /*public void fallThroughLevel()
    {
        

        SceneManager.LoadScene(0);
    }*/

    
}

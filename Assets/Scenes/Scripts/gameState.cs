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
        
        //this is called when player hits an obstacle
    }

    

    

  

    IEnumerator RestartLevel()
    {
        


        Time.timeScale = 1f / scaleSlowmo;      //slows time by dividing the scale with slowmo value
                                                //like 1/2, where 2 is the scale, time slows down to 0.5 from 1.0
        Time.fixedDeltaTime = Time.fixedDeltaTime / scaleSlowmo; //timescale is 1 by default
                                                                 //we use fixed deltatime, that is different from time.time, which we don't use, but it's run every time.
        yield return new WaitForSeconds(slowmoDuration / scaleSlowmo);

        
        
            
            Time.timeScale = Time.timeScale * scaleSlowmo;
            Time.fixedDeltaTime = Time.fixedDeltaTime * scaleSlowmo;
            //used to reset time, by dividing to remove the multiplier


            
            SceneManager.LoadScene("MainLevel01");
        //waits for 10 sec and then passes control to below code


        //loads the main level
    }

    

    
}

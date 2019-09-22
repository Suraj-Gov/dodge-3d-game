using UnityEngine;
using UnityEngine.UI;   //need to use this for UI

public class scoreUpdater : MonoBehaviour
{
    public Text score; //textUI for score

    void Update()
    {
        
        {
            score.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
            //updates the score in realtime by considering time survived as score
        } 
    }

}

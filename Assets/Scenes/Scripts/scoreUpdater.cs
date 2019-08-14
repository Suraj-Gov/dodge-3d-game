using UnityEngine;
using UnityEngine.UI;   //need to use this for UI
using TMPro;    //need to use this for TMPro UI

public class scoreUpdater : MonoBehaviour
{
    public TextMeshProUGUI score; //textUI for score

    void Update()
    {
        
        {
            score.text = Time.timeSinceLevelLoad.ToString("0");
            //updates the score in realtime by considering time survived as score
        } 
    }

}

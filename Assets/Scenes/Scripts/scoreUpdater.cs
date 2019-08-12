using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score;
    

    // Update is called once per frame
    void Update()
    {
        
        {
            score.text = Time.timeSinceLevelLoad.ToString("0");
        } 
    }

    public void endMessage()
    {
        Debug.Log("end level");
    }

    
}

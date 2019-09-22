using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text score;
    public Text highScoreText;

    public void Start()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScorePref", 0).ToString("0");
    }

    public void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > PlayerPrefs.GetFloat("HighScorePref", 0))
        PlayerPrefs.SetFloat("HighScorePref", Mathf.Round(Time.timeSinceLevelLoad));
    }
}

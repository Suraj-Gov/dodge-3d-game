using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScoreText;

    public void Start()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetFloat("HighScorePref", 0);
    }

    public void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > PlayerPrefs.GetFloat("HighScorePref", 0))
        PlayerPrefs.SetFloat("HighScorePref", Mathf.Round(Time.timeSinceLevelLoad));
    }
}

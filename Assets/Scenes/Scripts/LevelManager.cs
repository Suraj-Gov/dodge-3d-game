using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void helpScreenGo()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void startGameNow()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void endGameNow()
    {
        Application.Quit();
    }

    public void GoHelpScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class gobacktoMenu : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

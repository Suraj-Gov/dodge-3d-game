using UnityEngine;
using UnityEngine.SceneManagement;
 

public class levelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;

    public void Fade2Level()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainLevel01");
    }
    
    
}

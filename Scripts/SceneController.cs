using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int isTutorial;

    void Start()
    {
        LoadTutorialStatus();
    }

    void LoadTutorialStatus()
    {
        isTutorial = PlayerPrefs.GetInt("isTutorial");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        if (isTutorial == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (isTutorial == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTutotialToLobby : MonoBehaviour
{
    public int isTutorial = 0;

    void Start()
    {
        isTutorial = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTutorial = 1;
            isTutorialSave();
            SceneManager.LoadScene(2);
        }
    }

    void isTutorialSave()
    {
        PlayerPrefs.SetInt("isTutorial", isTutorial);
        PlayerPrefs.Save();
    }
}

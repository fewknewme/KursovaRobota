using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RubinsAdd : MonoBehaviour
{
    public static RubinsAdd instance;
    private bool isHandlingCollision = false;
    public GameObject E;
    public Image Rubin1Img;
    public Image Rubin2Img;
    public Image Rubin3Img;

    private bool rubin1 = false;
    private bool rubin2 = false;
    private bool rubin3 = false;

    public int saveRubin1 = 0;
    public int saveRubin2 = 0;
    public int saveRubin3 = 0;

    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        string sceneName = CurrentScene.name;
        if(sceneName == "Tutorial")
        {
            saveRubin1 = 0;
            saveRubin2 = 0;
            saveRubin3 = 0;
            PlayerPrefs.DeleteAll();
        }

        E.SetActive(false);
        Rubin1Img.enabled = false;
        Rubin2Img.enabled = false;
        Rubin3Img.enabled = false;

        // Завантаження збережених значень
        if (PlayerPrefs.HasKey("saveRubin1"))
        {
            saveRubin1 = PlayerPrefs.GetInt("saveRubin1");
        }
        if (PlayerPrefs.HasKey("saveRubin2"))
        {
            saveRubin2 = PlayerPrefs.GetInt("saveRubin2");
        }
        if (PlayerPrefs.HasKey("saveRubin3"))
        {
            saveRubin3 = PlayerPrefs.GetInt("saveRubin3");
        }

        // Встановлення зображень згідно збережених значень
        if (saveRubin1 == 1)
        {
            Rubin1Img.enabled = true;
        }
        if (saveRubin2 == 1)
        {
            Rubin2Img.enabled = true;
        }
        if (saveRubin3 == 1)
        {
            Rubin3Img.enabled = true;
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (!isHandlingCollision)
        {
            if (other.CompareTag("Rubin1"))
            {
                StartCoroutine(WaitForKeyPress(other.gameObject));
                E.SetActive(true);
                rubin1 = true;
            }
            else if (other.CompareTag("Rubin2"))
            {
                StartCoroutine(WaitForKeyPress(other.gameObject));
                E.SetActive(true);
                rubin2 = true;
            }
            else if (other.CompareTag("Rubin3"))
            {
                StartCoroutine(WaitForKeyPress(other.gameObject));
                E.SetActive(true);
                rubin3 = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rubin1") || other.CompareTag("Rubin2") || other.CompareTag("Rubin3"))
        {
            E.SetActive(false);
            isHandlingCollision = false;
            StopAllCoroutines();
            rubin1 = false;
            rubin2 = false;
            rubin3 = false;
        }
    }

    IEnumerator WaitForKeyPress(GameObject Rubin)
    {
        isHandlingCollision = true;

        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null;
        }

        StartCoroutine(HandleCollisionWithDelay(Rubin));
    }

    IEnumerator HandleCollisionWithDelay(GameObject Rubin)
    {
        if (rubin1)
        {
            Rubin1Img.enabled = true;
            saveRubin1 = 1;
            SaveRubin1();
        }
        if (rubin2)
        {
            Rubin2Img.enabled = true;
            saveRubin2 = 1;
            SaveRubin2();
        }
        if (rubin3)
        {
            Rubin3Img.enabled = true;
            saveRubin3 = 1;
            SaveRubin3();
        }

        Destroy(Rubin);

        yield return new WaitForSeconds(0.1f);

        isHandlingCollision = false;
        E.SetActive(false);
    }

    void SaveRubin1()
    {
        PlayerPrefs.SetInt("saveRubin1", saveRubin1);
        PlayerPrefs.Save();
    }
    void SaveRubin2()
    {
        PlayerPrefs.SetInt("saveRubin2", saveRubin2);
        PlayerPrefs.Save();
    }
    void SaveRubin3()
    {
        PlayerPrefs.SetInt("saveRubin3", saveRubin3);
        PlayerPrefs.Save();
    }
}

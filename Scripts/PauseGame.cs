using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame instance; 

    public GameObject PausePanel;
    private bool isPaused = false;
    private bool cursorWasVisible = false;
    private CursorLockMode previousLockState; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }


    }

    public void Pause()
    {
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        cursorWasVisible = Cursor.visible; 
        previousLockState = Cursor.lockState; 
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None; 
    }

    public void Continue()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = cursorWasVisible; 
        Cursor.lockState = previousLockState; 
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}

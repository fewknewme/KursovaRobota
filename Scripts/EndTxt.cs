using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class EndTxt : MonoBehaviour
{
    public TMP_Text text;
    private int Timer = 10;
    private float x = 0;
    private bool start = false;

    void Update()
    {
        if(start)
        {
            x+=Time.deltaTime;
            if(x>=1)
            {
                x = 0;
                Timer--;
            }

            text.text = "" + Timer;

            if(Timer == 0)
            {
                PlayerPrefs.DeleteAll();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(0);
            }
        }
        
    } 

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            start = true;
        }
    }
}

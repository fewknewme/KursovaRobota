using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpLevels : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lvl1"))
        {
            SceneManager.LoadScene(3);
        }

        if(other.CompareTag("Lvl2"))
        {
            SceneManager.LoadScene(4);
        }
        
        if(other.CompareTag("Lvl3"))
        {
            SceneManager.LoadScene(5);
        }
        
    }
}

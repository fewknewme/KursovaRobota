using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompliteLevels : MonoBehaviour
{

    public GameObject LvlTp1;
    public GameObject LvlTp2;
    public GameObject LvlTp3;

    public GameObject LvlBarier2;
    public GameObject LvlBarier3;
    public GameObject MainBarier;

    void Update()
    {
        if(PlayerPrefs.HasKey("saveRubin1"))
        {
            Destroy(LvlTp1);
            LvlBarier2.SetActive(false);
        }
        if(PlayerPrefs.HasKey("saveRubin2"))
        {
            Destroy(LvlTp2);
            LvlBarier3.SetActive(false);
        }

        if(PlayerPrefs.HasKey("saveRubin3"))
        {
            Destroy(LvlTp3);
            MainBarier.SetActive(false);
        }

    }
}

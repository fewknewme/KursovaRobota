using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Berserk : Damage
{
    public bool berserk = false;
    private float BerserkReloud = 20f;
    private float BerserkCurentReloud = 20f;
    private float BerserkBreakTime = 10f; 
    public UnityEngine.UI.Image berserkReloudImg;
    public UnityEngine.UI.Image berserkCameraImg;
    public UnityEngine.UI.Image berserkReloadBar;
    public UnityEngine.UI.Image berserkReloadBackground;
    public UnityEngine.UI.Image berserkReloudImageBackground;
    public TMP_Text Ztext;
    public UnityEngine.UI.Image Zimg;

    public bool level3 = false;     


    void Start()
    {
        if(PlayerPrefs.HasKey("saveRubin2"))
        {
            level3 = true;
        }
        if(level3)
        {
            berserkCameraImg.enabled = false;
            berserkReloadBackground.enabled = false;
            berserkReloadBar.enabled = false;
        }
        else
        {
            berserkCameraImg.enabled = false;
            berserkReloadBackground.enabled = false;
            berserkReloadBar.enabled = false;
            Ztext.enabled = false;
            Zimg.enabled = false;   
            berserkReloudImg.enabled = false;
            berserkReloudImageBackground.enabled = false;
        }   

    }

    void Update()
    {
        if(level3)
        {
            if (Input.GetKeyDown(KeyCode.Z) && BerserkCurentReloud >= BerserkReloud)
            {
                berserk = true;
                BerserkCurentReloud = 0f;
                base.damageAmount *= 2; 
                berserkCameraImg.enabled = true;
                berserkReloadBackground.enabled = true;
                berserkReloadBar.enabled = true;
            }

            if (berserk)
            {
                if (BerserkCurentReloud >= BerserkBreakTime)
                {
                    berserk = false;
                    berserkCameraImg.enabled = false;
                    base.damageAmount /= 2; 
                    berserkReloadBackground.enabled = false;
                    berserkReloadBar.enabled = false;
                }

            }

            berserkReloudImg.fillAmount = BerserkCurentReloud / BerserkReloud;

            if (BerserkCurentReloud <= BerserkReloud)
            {
                BerserkCurentReloud += Time.deltaTime;
            }

            berserkReloadBar.fillAmount = 1 - BerserkCurentReloud / BerserkBreakTime;
        }
    }
}

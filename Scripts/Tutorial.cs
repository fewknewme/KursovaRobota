using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Image Mouse;
    public TMP_Text MouseTxt;
    public Image WASD;
    public TMP_Text WASDTxt;
    public Image Spase;
    public TMP_Text SpaseTxt;
    public Image Shift;
    public TMP_Text ShiftTxt;
    public Image LMB;
    public TMP_Text LMBTxt;
    public Image Q;
    public TMP_Text QTxt;

    private int WASDInput = -1;
    private int SpaseInput = -1;
    private int ShiftInput = -1;
    private int LMBInput = -1;
    private int QInput = -1;

    public bool tutorial = false;

    public float TutorialTimer = 0f;

    void Start()
    {
        if(tutorial)
        {
            Mouse.enabled = true;
            MouseTxt.enabled = true;
        }
        else
        {
            Mouse.enabled = false;
            MouseTxt.enabled = false;
        }
        WASD.enabled = false;
        WASDTxt.enabled = false;
        Spase.enabled = false;
        SpaseTxt.enabled = false;
        Shift.enabled = false;
        ShiftTxt.enabled = false;
        LMB.enabled = false;
        LMBTxt.enabled = false;
        Q.enabled = false;
        QTxt.enabled = false;
    }

    void Update()
    {
        if(tutorial)
        {
            TutorialTimer+=Time.deltaTime;

            if(TutorialTimer >= 2)
            {
                Mouse.enabled = false;
                MouseTxt.enabled = false;
            }

            if(TutorialTimer >= 3 && TutorialTimer <= 18)
            {
                WASD.enabled = true;
                WASDTxt.enabled = true;
                WASDInput = 0;
            }
            else
            {
                WASD.enabled = false;
                WASDTxt.enabled = false;           
            }
            if(((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.Return))) && WASDInput == 0)
            {
                TutorialTimer = 18.1f;   
                WASDInput++;
            }

            if(TutorialTimer >= 19 && TutorialTimer <= 34)
            {
                Spase.enabled = true;
                SpaseTxt.enabled = true;
                SpaseInput = 0;
            }
            else
            {
                Spase.enabled = false;
                SpaseTxt.enabled = false;           
            }
            if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return))) && SpaseInput == 0)
            {
                TutorialTimer = 34.1f;   
                SpaseInput++;
            }

            if(TutorialTimer >= 35 && TutorialTimer <= 50)
            {
                Shift.enabled = true;
                ShiftTxt.enabled = true;
                ShiftInput = 0;
            }
            else
            {
                Shift.enabled = false;
                ShiftTxt.enabled = false;           
            }
            if(((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.LeftShift))) && ShiftInput == 0)
            {
                TutorialTimer = 50.1f;   
                ShiftInput++;
            }

            if(TutorialTimer >= 51 && TutorialTimer <= 66)
            {
                LMB.enabled = true;
                LMBTxt.enabled = true;
                LMBInput = 0;
            }
            else
            {
                LMB.enabled = false;
                LMBTxt.enabled = false;           
            }
            if(((Input.GetKeyDown(KeyCode.Mouse0)) || (Input.GetKeyDown(KeyCode.Return))) && LMBInput == 0)
            {
                TutorialTimer = 66.1f;   
                LMBInput++;
            }

            if(TutorialTimer >= 67 && TutorialTimer <= 82)
            {
                Q.enabled = true;
                QTxt.enabled = true;
                QInput = 0;
            }
            else
            {
                Q.enabled = false;
                QTxt.enabled = false;           
            }
            if(((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.Return))) && QInput == 0)
            {
                TutorialTimer = 82.1f;   
                QInput++;
            }
        }
        
    }


}

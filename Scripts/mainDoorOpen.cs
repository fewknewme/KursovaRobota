using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainDoorOpen : MonoBehaviour
{
    private Animator anim;
    public int countRubins = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(countRubins == 3)
        {
            anim.Play("MainDoorAnim");
        }
    }

    public void AddRubins()
    {
        countRubins++;
    }
}

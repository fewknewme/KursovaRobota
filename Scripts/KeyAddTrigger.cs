using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAddTrigger : MonoBehaviour
{
    public static KeyAddTrigger instance; 
    private bool isHandlingCollision = false; 
    public GameObject E;
    public Image KeyImg;

    void Start()
    {
        E.SetActive(false);
        KeyImg.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isHandlingCollision && other.CompareTag("Key"))
        {
            StartCoroutine(WaitForKeyPress(other.gameObject));
            E.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            E.SetActive(false); 
            isHandlingCollision = false; 
            StopAllCoroutines(); 
        }
    }

    IEnumerator WaitForKeyPress(GameObject Key)
    {
        isHandlingCollision = true;


        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null; 
        }

        StartCoroutine(HandleCollisionWithDelay(Key));
    }

    IEnumerator HandleCollisionWithDelay(GameObject Key)
    {
        Destroy(Key);
        KeyImg.enabled = true;

        yield return new WaitForSeconds(0.1f);


        isHandlingCollision = false;
        E.SetActive(false);
    }
}

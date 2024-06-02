using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiaddTrigger : MonoBehaviour
{
    public static KunaiaddTrigger instance; 
    private bool isHandlingCollision = false; 
    public GameObject E;

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
        E.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isHandlingCollision && other.CompareTag("Kunai"))
        {
            StartCoroutine(WaitForKeyPress(other.gameObject));
            E.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kunai"))
        {
            E.SetActive(false); 
            isHandlingCollision = false; 
            StopAllCoroutines(); 
        }
    }

    IEnumerator WaitForKeyPress(GameObject Kunai)
    {
        isHandlingCollision = true;


        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null; 
        }

        StartCoroutine(HandleCollisionWithDelay(Kunai));
    }

    IEnumerator HandleCollisionWithDelay(GameObject Kunai)
    {
        Destroy(Kunai);

        yield return new WaitForSeconds(0.1f);

        if (KunaiSpawner.instance != null)
        {
            KunaiSpawner.instance.OnKunaiEnterTrigger();
        }

        isHandlingCollision = false;
        E.SetActive(false);
    }
}

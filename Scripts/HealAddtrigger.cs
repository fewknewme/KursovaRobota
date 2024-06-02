using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAddtrigger : MonoBehaviour
{
    public static HealAddtrigger instance;
    public GameObject E;

    private bool isHandlingCollision = false;

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
        if (!isHandlingCollision && other.CompareTag("Heal"))
        {
            StartCoroutine(WaitForKeyPress(other.gameObject));
            E.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Heal"))
        {
            E.SetActive(false); 
            isHandlingCollision = false; 
            StopAllCoroutines(); 
        }
    }

    IEnumerator WaitForKeyPress(GameObject heal)
    {
        isHandlingCollision = true;

        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return null; 
        }

        StartCoroutine(HandleCollisionWithDelay(heal));
    }

    IEnumerator HandleCollisionWithDelay(GameObject heal)
    {
        Destroy(heal);

        yield return new WaitForSeconds(0.1f);


        if (PlayerHealth.instance != null)
        {
            PlayerHealth.instance.OnHealEnterTrigger();
        }

        isHandlingCollision = false;
        E.SetActive(false);
    }
}

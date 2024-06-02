using UnityEngine;
using UnityEngine.UI;

public class RubinStay_ : MonoBehaviour
{
    public GameObject E; // Об'єкт, який показує повідомлення "натисніть E"
    public GameObject Rubin; // Об'єкт, який буде активований
    public Image RubinImg; // Зображення, яке буде вимкнено
    private bool RubinStay = false;

    private bool playerInTrigger = false;

    public mainDoorOpen mainDoor;

    void Start()
    {
        E.SetActive(false);
        Rubin.SetActive(false);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if(!RubinStay)
            {
                E.SetActive(true);
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            E.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if(!RubinStay)
            {
                mainDoor.AddRubins();
            }
            Rubin.SetActive(true);
            RubinImg.enabled = false;
            RubinStay = true;
            E.SetActive(false);
        }
    }
}
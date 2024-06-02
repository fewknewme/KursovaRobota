using UnityEngine;
using UnityEngine.UI;

public class KeyDoor : MonoBehaviour
{
    public Image KeyImg;
    public GameObject E; 
    private bool isPlayerNearby = false; 
    private Animator anim;

    void Start()
    {
        E.SetActive(false);
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isPlayerNearby && KeyImg.enabled && Input.GetKeyDown(KeyCode.E))
        {
            E.SetActive(false); 
            KeyImg.enabled = false; 
            anim.SetBool("open", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (KeyImg.enabled)
            {
                E.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; 
            E.SetActive(false); 
        }
    }
}

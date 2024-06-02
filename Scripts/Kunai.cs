using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KunaiSpawner : MonoBehaviour
{
    public static KunaiSpawner instance; 

    public GameObject kunaiPrefab;
    public Transform kunaiSpawnPoint;
    public float spawnCooldown = 1f;
    private float spawnTimer = 0f;
    public Animator anim;
    private int maxCountKunais = 10;
    public int countKunais = 10;
    public TMP_Text Kunais;
    public Image KunaisReloud;
    private Collider colider; 

    public AudioClip throught;
    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (countKunais > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && spawnTimer <= 0f)
            {
                anim.Play("kunai");

                SpawnKunai();
                countKunais--;
                spawnTimer = spawnCooldown;
            }
        }

        Kunais.text = countKunais + "/" + maxCountKunais;
        KunaisReloud.fillAmount = spawnCooldown - spawnTimer;
    }

    public void OnKunaiEnterTrigger()
    {
        if (maxCountKunais > countKunais)
        {
            countKunais++;
        }
    }

    void SpawnKunai()
    {
        audioSource.PlayOneShot(throught);
        GameObject kunai = Instantiate(kunaiPrefab, kunaiSpawnPoint.position, kunaiSpawnPoint.rotation);
        kunai.GetComponent<Rigidbody>().AddForce(kunai.transform.right * 5f, ForceMode.Impulse);
    }
}

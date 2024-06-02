using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 0.5f;
    public bool isAttack;

    public GameObject YellowEyePrefab;
    public Transform SpawnYellowEye;
    public float attackCooldown = 7f;
    public float attackTimer = 0f;
    public GameObject LazerPrefab;
    public Transform LazerSpawnPoint;

    private GameObject currentYellowEye;
    private List<Enemy> enemies = new List<Enemy>();

    public float fallSpeed = 1f;
    public float shrinkSpeed = 1f;
    public float rotateSpeed = 30f;

    public float distanseToAttack1;
    public float distanseToAttack2;

    private AudioSource audioSource;
    public AudioClip Shoot;

    void Start()
    {
        Enemy[] foundEnemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in foundEnemies)
        {
            AddEnemyToBotList(enemy);
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        attackCooldown*=enemies.Count;
        audioSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.HP > 0)
            {
                if ((playerTransform.position - transform.position).magnitude < distanseToAttack1)
                {                
                    if((playerTransform.position - transform.position).magnitude > distanseToAttack2)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed/enemies.Count * Time.deltaTime);
                    }
                }

                
                else
                {
                    float currentHeight = transform.position.y;
                    float targetHeight = playerTransform.position.y;
                    float newHeight = Mathf.Lerp(currentHeight, targetHeight - 0.7f, Time.deltaTime * speed/enemies.Count);
                    transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
                }

                isAttack = (playerTransform.position - transform.position).magnitude < 6f;

                Vector3 direction = playerTransform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation.eulerAngles.y + 90f, transform.rotation.eulerAngles.z);

                attackTimer += Time.deltaTime;

                if (isAttack && attackTimer >= attackCooldown)
                {
                    if (currentYellowEye != null)
                    {
                        Destroy(currentYellowEye);
                    }
                    currentYellowEye = Instantiate(YellowEyePrefab, SpawnYellowEye.position, Quaternion.identity);
                    currentYellowEye.transform.parent = SpawnYellowEye;
                    attackTimer = 0f;

                    Invoke("SpawnLaser", 1.5f);
                }
            }
        }
    }

    void SpawnLaser()
    {
        audioSource.PlayOneShot(Shoot);
        GameObject lazer = Instantiate(LazerPrefab, SpawnYellowEye.position, LazerSpawnPoint.rotation);
        Destroy(lazer, 2f);
        StartCoroutine(MoveLaserToTarget(lazer.transform, playerTransform.position - SpawnYellowEye.position, 5f));
    }

    IEnumerator MoveLaserToTarget(Transform laser, Vector3 direction, float speed)
    {
        while (laser != null)
        {
            Vector3 initialPosition = laser.position;
            Vector3 newPosition = laser.position + new Vector3(direction.x * speed * Time.deltaTime, 0f, direction.z * speed * Time.deltaTime);
            laser.position = new Vector3(newPosition.x, initialPosition.y, newPosition.z);
            yield return null;
        }
    }

    public void AddEnemyToBotList(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    void OnDestroy()
    {
        if (currentYellowEye != null)
        {
            Destroy(currentYellowEye);
        }
    }
}

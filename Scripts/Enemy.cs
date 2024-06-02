using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float HP;
    private float fallSpeed = 1f;
    private float shrinkSpeed = 1f;
    private float rotateSpeed = 30f;
    private float currentRotation = 0f;
    public GameObject heal;
    public GameObject Key;

    public static List<Enemy> allEnemies = new List<Enemy>();

    public bool key = false;
    private bool isDestroyedByPlayer = false;

    public int EnemyCount;

    void Start()
    {
        if(key)
        {
            maxHP *=3; 
        }
        HP = maxHP;
        HP = Mathf.Floor(HP);

        allEnemies.Add(this);
    }

    void Update()
    {
        if (HP <= 0)
        {
            if (this.currentRotation < 94f)
            {
                transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
                this.currentRotation += rotateSpeed * Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                if (transform.localScale.x > 0)
                {
                    transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
                    if (transform.localScale.x <= 0f)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            isDestroyedByPlayer = true;
        }
    }

    void OnDestroy()
    {
        allEnemies.Remove(this);

        if (isDestroyedByPlayer)
        {
            if (!key)
            {
                if (Random.Range(1, 3) == 2)
                {
                    // Інстанціюємо об'єкт heal на позиції поточного об'єкта
                    Instantiate(heal, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                }
            }

            if (key)
            {
                Instantiate(Key, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            }
        }
    }
}

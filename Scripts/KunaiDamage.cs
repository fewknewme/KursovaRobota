using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiDamage : MonoBehaviour
{
    public float damageAmount = 7f;
    private PlayerAnims playersAnim;
    private Rigidbody rb;
    private KunaiSpawner kunai;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage((int)damageAmount);
            rb.isKinematic = true;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 60f);
            rb.isKinematic = true;
        }
        

    }
}

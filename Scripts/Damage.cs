using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 5f;
    [SerializeField]
    private PlayerAnims playersAnim; 

    private void Start()
    {
        if (playersAnim == null)
        {
            playersAnim = GameObject.FindObjectOfType<PlayerAnims>();

            if (playersAnim == null)
            {
                Debug.LogError("PlayerAnims component not found!");
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playersAnim == null)
        {
            Debug.LogError("PlayerAnims is not initialized!");
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            if (playersAnim.countDamage == 0)
            {
                playersAnim.ChangeCountDamage(1);
                other.GetComponent<Enemy>().TakeDamage((int)damageAmount);
            }
        }
    }
}

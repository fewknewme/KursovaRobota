using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private float maxHealth = 500f; 
    public float currentHealth; 
    public Image healthSlider; 

    private float shieldTime = 10f;
    private float shieldHP;
    private float shieldMaxHP;
    private float shieldReload = 20f;
    private float shieldCurrentReload = 20f;

    public Image backgroundCooldown;
    public Image timerCooldown;
    public Image shieldCooldown;
    public Image shield;
    public Image ShieldReloudIcon;
    public TMP_Text Xtxt;
    public Image Xbackground;

    public Image Cbtn;
    public TMP_Text Ctxt;
    private int CInput = 0;

    public Image healFill;
    private float healFillCooldown = 2f;
    private float healFillCurrentCooldown = 2f;
    public TMP_Text Text;

    private int MaxCountHeals = 15;
    public int CountHeals = 0;

    public static PlayerHealth instance;

    public bool Tutorial = false;

    public bool leevel2 = false;

    public GameObject DeathScrean;

    private void Awake()
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
        DeathScrean.SetActive(false);
        if(PlayerPrefs.HasKey("saveRubin1"))
        {
            leevel2 = true;
        }
        
        currentHealth = maxHealth;
        shieldMaxHP = maxHealth * 0.4f;

        UpdateHealthUI();
        if(leevel2)
        {
            backgroundCooldown.enabled = false;
            timerCooldown.enabled = false;
            shield.enabled = false;
        }
        else
        {
            backgroundCooldown.enabled = false;
            timerCooldown.enabled = false;
            shield.enabled = false;
            ShieldReloudIcon.enabled = false;
            shieldCooldown.enabled = false;
            Xtxt.enabled = false;
            Xbackground.enabled = false;
        }

        if(Tutorial)
        {
            Cbtn.enabled = false;
            Ctxt.enabled = false;
        }
    }
    

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }


        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (shieldCurrentReload >= shieldReload)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Shield();
                shield.enabled = true;
            }
        }

        if (shieldCurrentReload < shieldReload)
        {
            shieldCurrentReload += Time.deltaTime;
        }

        if (shieldCooldown.enabled && shieldTime < 10f)
        {
            shieldTime += Time.deltaTime;
        }
        else
        {
            shield.enabled = false;
            
        }
        if(shield.enabled)
        {
            backgroundCooldown.enabled = true;
            timerCooldown.fillAmount = (10f - shieldTime) / 10f;
        }
        else
        {
            backgroundCooldown.enabled = false;
            timerCooldown.fillAmount = 0f;

        }
        if (shieldHP <= 0)
        {
            shield.enabled = false;
        }

        if (shieldCooldown.enabled)
        {
            timerCooldown.enabled = true;
        }
        else
        {
            timerCooldown.enabled = false;
            shieldCurrentReload = 15f;
        }

        shieldCooldown.fillAmount = shieldCurrentReload / shieldReload;
        healFill.fillAmount = healFillCurrentCooldown / healFillCooldown;

        if (healFillCurrentCooldown < healFillCooldown)
        {
            healFillCurrentCooldown += Time.deltaTime;
        }
        else if (healFillCurrentCooldown >= healFillCooldown)
        {
            if (Input.GetKeyDown(KeyCode.C) && CountHeals>0 && currentHealth < maxHealth)
            {
                healFillCurrentCooldown = 0f;
                Heal();
                
            }
        }


        Text.text = CountHeals + "/" + MaxCountHeals;

        if(currentHealth < maxHealth && CInput == 0 && Tutorial)
        {
            Cbtn.enabled = true;
            Ctxt.enabled = true;
            if((Input.GetKeyDown(KeyCode.C)) || (Input.GetKeyDown(KeyCode.Return)))
            {
                CInput++;
                Cbtn.enabled = false;
                Ctxt.enabled = false;
            }
        }
        else
        {
            Cbtn.enabled = false;
            Ctxt.enabled = false;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (shield.enabled)
        {
            shieldHP -= damageAmount;
        }
        else
        {
            currentHealth -= damageAmount;
        }

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthSlider.fillAmount = currentHealth / maxHealth;
    }

    void Die()
    {
        DeathScrean.SetActive(true);
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Tutorial && currentHealth >= (maxHealth*0.5))
        {
            if (other.CompareTag("LaserBot"))
            {
                int damageAmount = 10;
                TakeDamage(damageAmount);
            }

            if (other.CompareTag("LaserDron"))
            {
                int damageAmount = 20;
                TakeDamage(damageAmount);
            }

            if (other.CompareTag("LaserSnake"))
            {
                int damageAmount = 6;
                TakeDamage(damageAmount);
            }
        }
        else if (!Tutorial)
        {
            if (other.CompareTag("LaserBot"))
            {
                int damageAmount = 10;
                TakeDamage(damageAmount);
            }

            if (other.CompareTag("LaserDron"))
            {
                int damageAmount = 20;
                TakeDamage(damageAmount);
            }

            if (other.CompareTag("LaserSnake"))
            {
                int damageAmount = 6;
                TakeDamage(damageAmount);
            }
        }
        
    }

    private void Shield()
    {
        if (shieldCurrentReload >= shieldReload)
        {
            shieldHP = shieldMaxHP;
            shieldCooldown.enabled = true;
            shieldCurrentReload = 0f;
            shieldTime = 0;
        }
        else
        {
            shieldCooldown.enabled = false;
        }
    }

    private void Heal()
    {
        currentHealth = currentHealth + (maxHealth * 0.2f);
        CountHeals--;
        UpdateHealthUI();
    }

    public void OnHealEnterTrigger()
    {

        if (CountHeals < MaxCountHeals)
        {
            if (MaxCountHeals > CountHeals)
            {
                CountHeals++;
            }
        }
    }
}

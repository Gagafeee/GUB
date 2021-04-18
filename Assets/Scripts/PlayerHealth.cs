using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public AudioClip hitSound;
    public bool GameIsPaused;

    public static PlayerHealth instance;
    public Animator PayerHeartAnnimator;
    public bool isDie;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 30)
        {
            PayerHeartAnnimator.SetBool("30%", true);
        }
        if (currentHealth > 30)
        {
            PayerHeartAnnimator.SetBool("30%", false);
        }
    }

    public void HealPlayer(int amount)
    {
        if (currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        Statistic.Instance.regeneration += amount;

    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {

            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            StartCoroutine(TakeDamageAnnimation(damage));
            LoadAndSaveData.instance.SaveData();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator TakeDamageAnnimation(int Damage)
    {
        for (var l = Damage; l > 0; l--)
        {
            currentHealth--;
            Statistic.Instance.damage++;
            if (currentHealth == 0)
            {
                Die();
                PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health", 100);
            }
            healthBar.SetHealth(currentHealth);
            yield return new WaitForSeconds(0.005f);
        }
    }

    public void Die()
    {
        Statistic.Instance.dead++;
        LoadAndSaveData.instance.SaveStatistics();
        LoadAndSaveData.instance.SaveData();
        isDie = true;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        CurrentSceneManager.instance.RespawnPoint = new Vector3(-46, 3, 0);
        CurrentSceneManager.instance.isTheFirstEnterInLevel = true;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.playerCollider.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        this.transform.position.Set(CurrentSceneManager.instance.RespawnPoint.x, CurrentSceneManager.instance.RespawnPoint.y, CurrentSceneManager.instance.RespawnPoint.z);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        LoadAndSaveData.instance.LoadStatistics();
        isDie = false;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

    
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform healthbar;
    public RectTransform heart;

    public SpriteRenderer spriteRenderer;

    public AudioSource playerAudio;
    public AudioClip playerHurt;
    public AudioClip playerDeath;

    public int maxHealth;

    public float invincibilityTime;
    public float vulnerabilityTime;

    public bool damageOverTimeIsActive;
    public bool isInvincible;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        if(isInvincible == true)
        {
            return;
        }

        StartCoroutine(IFrames());

        if (healthbar.childCount <= 1)
        {
            StartCoroutine(PlayerDeath());
            return;
        }

        StartCoroutine(ChangeColor(Color.red));

        Destroy(healthbar.GetChild(healthbar.childCount - 1).gameObject);
        playerAudio.PlayOneShot(playerHurt);
    }

    public IEnumerator IFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.1f);
        isInvincible = false;
    }


    public void StartTakeDamageOverTime(float damageInterval, float ticksOfDamage, Color color)
    {
        if (!damageOverTimeIsActive)
        {
            StartCoroutine(TakeDamageOverTime(damageInterval, ticksOfDamage, color));
        }
    }

    public IEnumerator TakeDamageOverTime(float damageInterval, float ticksOfDamage, Color color) 
    {
        damageOverTimeIsActive = true;
        for (int i = 0; i < ticksOfDamage; i++)
        {
            TakeDamage();
            StartCoroutine(ChangeColor(color));
            yield return new WaitForSeconds(damageInterval);
        }
        damageOverTimeIsActive = false;
    }

    public IEnumerator ChangeColor(Color color)
    {
        Color defaultColor = spriteRenderer.color;

        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.2f);

        if (defaultColor != Color.white)
        {
            spriteRenderer.color = Color.white;
            yield break;
        }
        spriteRenderer.color = defaultColor;
    }

    public void Heal(int healingAmount)
    {
        for(int i = 0; i < healingAmount; i++)
        {
            Instantiate(heart, healthbar);
        }
    }

    public IEnumerator Invincibility()
    {
        while (true)
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibilityTime);
            isInvincible = false;
            yield return new WaitForSeconds(vulnerabilityTime);
        }
    }

    public IEnumerator PlayerDeath()
    {
        playerAudio.PlayOneShot(playerDeath);
        yield return new WaitForSeconds(playerDeath.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetCurrentHealth()
    {
        return healthbar.childCount;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int maxHealthIncrease)
    {
        maxHealth += maxHealthIncrease;
    }
}

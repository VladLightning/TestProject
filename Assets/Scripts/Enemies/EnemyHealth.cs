using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public int increaseCoinsAmount;
    public bool damageOverTimeIsActive;
    public bool isInvincible;
    
    public Animator animator;
    public CoinPickUp coinPickUp;
    public SpriteRenderer spriteRenderer;
    public GameObject soundSource;
    public AudioSource enemyAudio;
    public AudioClip enemyHurt;
    public AudioClip enemyDeath;

    private void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Heal(float healingAmount)
    {
        health += healingAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if(isInvincible)
        {
            return;
        }
        health -= damage;

        if (health <= 0)
        {
            Death();
            return;
        }

        if(TryGetComponent(out BossAbility bossAbility) && health < maxHealth / 2)
        {
            bossAbility.Teleport();
            if(health < maxHealth / 4)
            {
                bossAbility.CloneSelf();
                isInvincible = true;
            }
        }

        if(TryGetComponent(out EnemyMask mask))
        {
            mask.StartDisableMask();
        }

        StartCoroutine(ChangeColor(Color.red));
        enemyAudio.PlayOneShot(enemyHurt);
    }

    public void StartTakeDamageOverTime(float damage, float damageInterval, int ticksOfDamage, Color color)
    {
        if (!damageOverTimeIsActive)
        {
            StartCoroutine(TakeDamageOverTime(damage, damageInterval, ticksOfDamage, color));
        }     
    }

    public IEnumerator TakeDamageOverTime(float damage, float damageInterval, int ticksOfDamage, Color color)
    {
        damageOverTimeIsActive = true;
        for(int i = 0; i < ticksOfDamage; i++)
        {
            TakeDamage(damage);
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

        if(defaultColor != Color.white)
        {
            spriteRenderer.color = Color.white;
            yield break;
        }
        spriteRenderer.color = defaultColor;
    }

    public void Death()
    {
        StopAllCoroutines();
        if(health <= -999)
        {
            return;
        }

        health = -999;

        GameObject soundSourceEmpty = Instantiate(soundSource, transform.position, transform.rotation);
        soundSourceEmpty.GetComponent<AudioSource>().volume = enemyAudio.volume;
        soundSourceEmpty.GetComponent<PlaySound>().PlayAudio(enemyDeath);

        if(TryGetComponent(out FollowTarget followTarget))
        {
            followTarget.enabled = false;
        }
        GetComponent<Collider2D>().enabled = false;
        if(transform.childCount > 0)
        {
           Destroy(transform.GetChild(0).gameObject);
        }
       
        animator.Play("Death");

        if (TryGetComponent(out EnemySplit enemySplit))
        {
            enemySplit.Split();
        }
        if(TryGetComponent(out Clone clone))
        {
            clone.CallDecreaseClonesAmount();
        }
        if(TryGetComponent(out BossDeath bossDeath))
        {
            bossDeath.FinishLevel();
        }    
        if (transform.parent.TryGetComponent(out BattleEnd battleEnd))
        {
            battleEnd.DecreaseEnemyAmount();
        }
       
        coinPickUp.IncreaseCoinsAmount(increaseCoinsAmount);
        Destroy(gameObject, 2);
    }

    public void SetIsInvincible(bool value)
    {
        isInvincible = value;
    }

    public bool GetIsInvincible()
    {
        return isInvincible;
    }

    public void SetHealth(float value)
    {
        health = value;
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PoisonToad : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public EnemyHealth bossHealth;
    public BossWeapon weapon;
    public FollowTarget followTarget;

    public enum ToadStates
    {
        Idle = 0,
        Moving = 1,
        Charging = 2,
        Attacking = 3,
    }
    public ToadStates toadState;

    public float knockbackThreshold;
    public float knockbackForce;
    public float jumpForce;
    public float jumpCooldown;
    public bool knockbackIsActive;
    public bool abilityReady;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        followTarget = GetComponent<FollowTarget>();
        target = followTarget.GetTarget();
        knockbackThreshold = followTarget.GetStoppingDistance();
        
        bossHealth = GetComponent<EnemyHealth>();
        weapon = GetComponentInChildren<BossWeapon>();
        animator = GetComponent<Animator>();

        toadState = ToadStates.Moving;
        abilityReady = true;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < knockbackThreshold 
                           && !knockbackIsActive && toadState == ToadStates.Moving
                           && abilityReady)
        {
            StartCoroutine(Knockback());
        }
        if(Vector2.Distance(transform.position, target.position) > knockbackThreshold &&
           Vector2.Distance(transform.position, target.position) < knockbackThreshold * 2 
           && abilityReady && !knockbackIsActive)
        {
            StartCoroutine(Jump());
        }

        if(Vector2.Distance(transform.position, target.position) > knockbackThreshold * 2 && !weapon.GetIsActive() && !knockbackIsActive)
        {
            bossHealth.SetIsInvincible(true);
            weapon.StartShoot();
        }
        else if(Vector2.Distance(transform.position, target.position) < knockbackThreshold * 2 && weapon.GetIsActive())
        {
            bossHealth.SetIsInvincible(false);
            weapon.ExecuteStopShoot();
        }

        if(Vector2.Distance(transform.position, target.position) > knockbackThreshold * 2 && toadState != ToadStates.Idle)
        {
            toadState = ToadStates.Idle;
            animator.Play("Idle");
            followTarget.SetSpeed(0);
        }
        else if(Vector2.Distance(transform.position, target.position) < knockbackThreshold * 2 && toadState != ToadStates.Moving)
        {
            toadState = ToadStates.Moving;
            animator.Play("Walk");
            followTarget.SetSpeedToDefault();
        }
    }

    public IEnumerator Knockback()
    {
        knockbackIsActive = true;

        animator.Play("Attack");
        bossHealth.SetIsInvincible(true);
        followTarget.SetSpeed(0);

        yield return new WaitForSeconds(1.1f);

        var playerMovement = target.GetComponent<PlayerMovement>();

        playerMovement.enabled = false;    

        Vector2 direction = (target.position - transform.position).normalized;
        target.GetComponent<Rigidbody2D>().AddForce(knockbackForce * direction);
        
        yield return new WaitForSeconds(0.5f);

        playerMovement.enabled = true;
        
        bossHealth.SetIsInvincible(false);
        followTarget.SetSpeedToDefault();
        
        knockbackIsActive = false;
    }

    public IEnumerator Jump()
    {
        abilityReady = false;
        toadState = ToadStates.Attacking;

        yield return new WaitForSeconds(0.3f);

        followTarget.SetSpeed(0);
        animator.Play("Attack");

        yield return new WaitForSeconds(0.8f);

        Vector2 direction = target.position - transform.position;
        rigidBody.AddForce(jumpForce * direction);

        yield return new WaitForSeconds(0.5f);

        toadState = ToadStates.Idle;
        animator.Play("Idle");

        yield return new WaitForSeconds(2);

        toadState = ToadStates.Moving;
        animator.Play("Walk");
        followTarget.SetSpeedToDefault();

        yield return new WaitForSeconds(jumpCooldown);
        abilityReady = true;
    }
}

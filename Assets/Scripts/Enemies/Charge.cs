using System.Collections;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public FollowTarget followTarget;
    public enum SlimeStates
    {
        Attacking = 0,
        Charging = 1,
        Moving = 2,
    }
    public SlimeStates slimeState;

    public float attackDistance;
    public float attackDelay;
    public float attackForce;
    public bool abilityReady;

    private void Start()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        followTarget = GetComponentInParent<FollowTarget>();

        slimeState = SlimeStates.Moving;
        abilityReady = true;
    }

    private void Update()
    {
        if(Vector2.Distance(player.position, transform.position) <= attackDistance && abilityReady) 
        {
            StartChargeAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && slimeState == SlimeStates.Attacking)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage();
        }
    }

    public void StartChargeAttack()
    {
        StartCoroutine(ChargeAttack());
    }

    public IEnumerator ChargeAttack()
    {
        abilityReady = false;
        slimeState = SlimeStates.Charging;
        Vector2 playerPosition = player.position;

        followTarget.SetSpeed(0);

        yield return new WaitForSeconds(attackDelay);

        animator.Play("Attack");

        yield return new WaitForSeconds(0.5f);

        slimeState = SlimeStates.Attacking;
        Vector2 direction = playerPosition - (Vector2)transform.position;
        rigidBody.AddForce(attackForce * direction);
        yield return new WaitForSeconds(0.8f);

        slimeState = SlimeStates.Moving;
       
        followTarget.SetSpeedToDefault();
        yield return new WaitForSeconds(attackDelay * 5);
        abilityReady = true;
    }
}

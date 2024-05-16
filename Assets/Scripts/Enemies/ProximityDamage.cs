using System.Collections;
using UnityEngine;

public class ProximityDamage : MonoBehaviour
{
    public Animator animator;
    public int damageInterval;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            StartCoroutine(DealDamage(playerHealth));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator DealDamage(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(damageInterval / 2);
        while(true)
        {
            playerHealth.TakeDamage();
            animator.Play("Attack");
            yield return new WaitForSeconds(damageInterval);
        }
    }
}

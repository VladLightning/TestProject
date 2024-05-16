using UnityEngine;

public class EnemyHeal : MonoBehaviour
{

    public float healingAmount;
    public float healingRadius;
    public float healingInterval;

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip healingSound;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponentInParent<AudioSource>();
        InvokeRepeating(nameof(Heal), healingInterval, healingInterval);
    }

    public void Heal()
    {
        audioSource.PlayOneShot(healingSound);
        animator.Play("Heal");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, healingRadius, LayerMask.GetMask("Enemy"));

        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<EnemyHealth>().Heal(healingAmount);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, healingRadius);
    }
}

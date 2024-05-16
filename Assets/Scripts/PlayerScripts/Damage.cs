using UnityEngine;

public class Damage : MonoBehaviour
{
    public float playerDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(collision);
        }
    }

    public void DealDamage(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
    }

    public void SetPlayerDamage(float damage)
    {
        playerDamage = damage;
    }
}

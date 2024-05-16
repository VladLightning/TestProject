using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public Color color;
    public float damageInterval;
    public float damage;
    public int ticksOfDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().StartTakeDamageOverTime(damage, damageInterval, ticksOfDamage, color);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().StartTakeDamageOverTime(damageInterval, ticksOfDamage, color);
        }
    }
}

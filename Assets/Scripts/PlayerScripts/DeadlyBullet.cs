using UnityEngine;

public class DeadlyBullet : MonoBehaviour
{
    public float deadlyDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent(out BossDeath bossDeath))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(deadlyDamage * 2);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(deadlyDamage * 10);
            }
        }
    }
}

using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    public int healingAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth.GetCurrentHealth() < playerHealth.GetMaxHealth())
            {
                playerHealth.Heal(healingAmount);
                Destroy(gameObject);
            }
        }
    }
}

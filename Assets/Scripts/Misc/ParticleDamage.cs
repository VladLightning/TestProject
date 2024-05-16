using UnityEngine;

public class ParticleDamage : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}

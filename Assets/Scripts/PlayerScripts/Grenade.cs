using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float disappearTimer;
    public float speed;
    public float damage;
    public float explosionRadius;
    public float forceMultiplier;
    public float knockbackForce;

    public GameObject particles;
    public GameObject soundSource;
    public AudioClip explosionSound;
    public Rigidbody2D rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * speed);

        Invoke(nameof(Explosion), disappearTimer - 0.1f);
        Destroy(gameObject, disappearTimer);
    }

    public void Explosion()
    {
        Instantiate(soundSource, transform.position, transform.rotation).GetComponent<PlaySound>().PlayAudio(explosionSound);
        Instantiate(particles, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius,LayerMask.GetMask("Enemy"));

        for (int i = 0; i < colliders.Length; i++)
        {
            float distance = Vector2.Distance(colliders[i].transform.position, transform.position);
            forceMultiplier = 1 / distance;
            colliders[i].GetComponent<EnemyHealth>().TakeDamage(damage * forceMultiplier);
            ExplosionKnockback(colliders[i].gameObject);
        }
    }

    public void ExplosionKnockback(GameObject objectToPush)
    {
        Vector2 direction = objectToPush.transform.position - transform.position;
        objectToPush.GetComponent<Rigidbody2D>().AddForce(knockbackForce * forceMultiplier * direction);    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}

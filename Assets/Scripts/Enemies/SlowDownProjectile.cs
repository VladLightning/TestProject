using UnityEngine;

public class SlowDownProjectile : MonoBehaviour
{
    public float disappearTimer;
    public float projectileSpeed;
    public float slowdownCoef;
    public float slowdownDuration;

    public Rigidbody2D rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * projectileSpeed);
        Destroy(gameObject, disappearTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatuses>().StartSlowDownPlayer(slowdownCoef, slowdownDuration);
        }
        Destroy(gameObject);
    }
}

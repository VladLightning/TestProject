using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float disappearTimer;
    public float bulletSpeed;
    public GameObject particles;
    public Rigidbody2D rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * bulletSpeed);
        Destroy(gameObject, disappearTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

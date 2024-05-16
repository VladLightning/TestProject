using UnityEngine;

public class Ball : MonoBehaviour
{
    public float timer;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        Destroy(gameObject, timer);
    }
}

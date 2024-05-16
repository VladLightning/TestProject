using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tpLink;
    public AudioSource portal;
    public AudioClip[] portalSounds; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        collision.gameObject.transform.position = tpLink.position;
        portal.PlayOneShot(portalSounds[Random.Range(0, portalSounds.Length)]);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.isTrigger = false;
    }
}

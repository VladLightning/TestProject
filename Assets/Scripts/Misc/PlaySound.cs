using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayAudio(AudioClip clipSet)
    {
        audioSource.PlayOneShot(clipSet);
        Destroy(gameObject, clipSet.length);
    }
}

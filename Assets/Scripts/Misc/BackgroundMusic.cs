using System.Collections;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip defaultMusic;

    public float defaultVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        defaultVolume = audioSource.volume;
        audioSource.clip = defaultMusic;
        audioSource.Play();
    }

    public void StartChangeMusic(AudioClip newMusic)
    {
        StartCoroutine(ChangeMusic(newMusic));
    }

    public void SetMusicToDefault()
    {
        StartCoroutine(ChangeMusic(defaultMusic));
    }

    public IEnumerator ChangeMusic(AudioClip newMusic)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.005f;
            yield return new WaitForSeconds(0.2f);
        }
        audioSource.clip = newMusic;
        audioSource.Play();
        while (audioSource.volume < defaultVolume)
        {
            audioSource.volume += 0.005f;
            yield return new WaitForSeconds(0.2f);
        }    
    }
}

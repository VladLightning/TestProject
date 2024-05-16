using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject spawnerToActivate;
    public BackgroundMusic backgroundMusic;
    public AudioClip replaceClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateTrap();
            Destroy(gameObject);
        }
    }

    public void ActivateTrap()
    {
        backgroundMusic.StartChangeMusic(replaceClip);

        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            objectsToActivate[i].SetActive(true);
        }
        spawnerToActivate.SetActive(true);
    }
}

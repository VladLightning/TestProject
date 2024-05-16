using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ColdRoom : MonoBehaviour
{
    public bool isActive;
    public float damageInterval;
    public float timeLimit;

    public GameObject roomTeleport;

    public RectTransform sliderPlacement;
    public Slider slider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {        
            StartChallenge(collision);         
        }
    }

    public void StartChallenge(Collider2D collision)
    {
        GetComponent<Timer>().StartTimer();
        timeLimit = GetComponent<Timer>().GetTime();

        slider = Instantiate(slider, sliderPlacement);
        roomTeleport.SetActive(false);

        StartCoroutine(Freeze(collision));
        StartCoroutine(SliderFill());
        StartCoroutine(EndChallenge(collision));
    }

    public IEnumerator EndChallenge(Collider2D collision)
    {
        yield return new WaitForSeconds(timeLimit - 0.1f);

        PostProcessVolume volume = collision.GetComponent<PlayerStatuses>().GetCamera().GetComponents<PostProcessVolume>()[1];
        volume.profile.TryGetSettings(out Vignette vignette);
        vignette.intensity.value = 0;

        collision.transform.position = roomTeleport.transform.position;
        Destroy(slider.gameObject);
        Destroy(roomTeleport);
    }

    public IEnumerator SliderFill()
    {
        slider.value = 0;

        while (true)
        {
            slider.value += 1 / timeLimit;
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Freeze(Collider2D collision)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();
        IEnumerator damage = FreezeDamage(playerHealth);

        PostProcessVolume volume = collision.GetComponent<PlayerStatuses>().GetCamera().GetComponents<PostProcessVolume>()[1];
        volume.profile.TryGetSettings(out Vignette vignette);
        volume.priority = 2;

        while (true)
        {
            if (vignette.intensity.value >= 1 && !isActive)
            {               
                StartCoroutine(damage);
                isActive = true;
            }
            else if (vignette.intensity.value < 1 && isActive)
            {
                StopCoroutine(damage);
                isActive = false;
            }
            vignette.intensity.value += 0.02f;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator FreezeDamage(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(1);
        while (true)
        {   
            playerHealth.TakeDamage();
            yield return new WaitForSeconds(damageInterval);
        }
    }
}

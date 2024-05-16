using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HeatPotion : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnFreeze(collision);
            Destroy(gameObject);
        }
    }

    public void UnFreeze(Collider2D collision)
    {
        PostProcessVolume volume = collision.GetComponent<PlayerStatuses>().GetCamera().GetComponents<PostProcessVolume>()[1];
        volume.profile.TryGetSettings(out Vignette vignette);
        vignette.intensity.value = 0f;
    }
}

using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStatuses : MonoBehaviour
{
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;

    public float remainingLifetime;

    public IEnumerator slowDown;
    public IEnumerator blind;
    public IEnumerator unblind;

    private void Update()
    {
        if(remainingLifetime >= 0)
        {
            remainingLifetime -= Time.deltaTime;
        }
    }

    public void StartSlowDownPlayer(float coef, float duration)
    {
        if(slowDown != null)
        {
            StopCoroutine(slowDown);
            slowDown = SlowDownPlayer(coef, remainingLifetime + duration);
            StartCoroutine(slowDown);
        }
        else
        {
            slowDown = SlowDownPlayer(coef, duration);
            StartCoroutine(slowDown);
        }

    }

    public IEnumerator SlowDownPlayer(float coef, float duration)
    {
        var playerMovement = GetComponent<PlayerMovement>();
        playerMovement.SetSpeedModifier(coef);

        remainingLifetime = duration;
        yield return new WaitForSeconds(duration);

        playerMovement.SetSpeedModifier(1);
        slowDown = null;
    }

    public void StartBlind()
    {
        if(unblind != null)
        {
            StopCoroutine(unblind);
        }
        blind = Blind();
        StartCoroutine(blind);
    }

    public IEnumerator Blind()
    {
        mainCamera.GetComponent<PostProcessVolume>().profile.TryGetSettings(out Vignette vignette);
        
        while (vignette.intensity < 1)
        {
            vignette.intensity.value += 0.02f;
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    public void StartUnBlind()
    {
        if(blind != null)
        {
            StopCoroutine(blind);
        }
        unblind = UnBlind();
        StartCoroutine(unblind);
    }

    public IEnumerator UnBlind()
    {
        mainCamera.GetComponent<PostProcessVolume>().profile.TryGetSettings(out Vignette vignette);

        while (vignette.intensity > 0)
        {
            vignette.intensity.value -= 0.005f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }

    public CinemachineVirtualCamera GetVirtualCamera()
    {
        return virtualCamera;
    }
}

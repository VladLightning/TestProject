using System.Collections;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public IEnumerator shoot;

    public GameObject bullet;
    public Transform[] bulletLaunchPoints;

    public AudioSource weaponAudioSource;
    public AudioClip shootingSound;

    public float shootingInterval;
    public int[] randomBulletNumbers;
    public bool activateOnStart;
    public bool isActive;

    private void Start()
    {
        weaponAudioSource = GetComponent<AudioSource>();
        if (activateOnStart)
        {
            shoot = Shoot();
            StartCoroutine(shoot);
        }
    }

    public void StartShoot()
    {
        if(shoot == null)
        {
            shoot = Shoot();
            StartCoroutine(shoot);
            isActive = true;
        }
    }

    public void ExecuteStopShoot()
    {
        StartCoroutine(StopShoot());
    }

    public IEnumerator StopShoot()
    {
        yield return new WaitForSeconds(1);
        if(shoot != null)
        {
            StopCoroutine(shoot);
            shoot = null;
            isActive = false;
        }

    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            int length = randomBulletNumbers[Random.Range(0, randomBulletNumbers.Length)];
            for (int i = 0; i < length; i++)
            {
                Instantiate(bullet, bulletLaunchPoints[i].position, bulletLaunchPoints[i].rotation);
            }
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}

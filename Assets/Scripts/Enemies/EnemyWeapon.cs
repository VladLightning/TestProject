using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] bulletLaunchPoints;

    public AudioSource weaponAudioSource;
    public AudioClip shootingSound;

    public float shootingDelay;

    public void Start()
    {
        weaponAudioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Shoot),shootingDelay, shootingDelay);
    }

    public void Shoot()
    {
        for (int i = 0; i < bulletLaunchPoints.Length; i++)
        {
            Instantiate(bullet, bulletLaunchPoints[i].position, bulletLaunchPoints[i].rotation);
        }
        weaponAudioSource.PlayOneShot(shootingSound);
    }
}

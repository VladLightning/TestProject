using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject specialBullet;
    public AudioSource shooting;

    public float shotDelay;
    public float lastShotTime;
    public float damage;
    public float specialBulletChance;

    private void Start()
    {
        lastShotTime = -shotDelay;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > shotDelay + lastShotTime)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        shooting.Play();
        if (specialBullet != null && Random.value < specialBulletChance)
        {
            SpawnBullet(specialBullet);
            return;
        }
        SpawnBullet(bullet);
        lastShotTime = Time.time;
    }

    public void SpawnBullet(GameObject bullet)
    {
        GameObject pistolBullet = Instantiate(bullet, transform.position, transform.rotation);
        pistolBullet.GetComponent<Damage>().SetPlayerDamage(damage);
    }

    public void SetSpecialBullet(GameObject setBullet)
    {
        specialBullet = setBullet;
    }

    public void IncreaseDamage(float damageIncrease)
    {
        damage += damageIncrease;
    }
}

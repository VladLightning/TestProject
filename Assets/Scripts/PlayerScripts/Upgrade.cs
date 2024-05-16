using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject deadlyBullet;
    public GameObject fireBullet;
    public GameObject poisonBullet;
    public GameObject grenadeAbility;
    public GameObject vinesAbility;
    public GameObject vortexAbility;
    public Transform abilityPosition;


    public float speedIncrease;
    public float damageIncrease;
    public int healthIncrease;
    public int increaseMultiplier;


    public void ReceiveItem(string item)
    {
        switch (item)
        {
            case "Hat of Swiftness":
                GetComponent<PlayerMovement>().SetSpeed(speedIncrease);
                break;

            case "Heart":
                GetComponent<PlayerHealth>().SetMaxHealth(healthIncrease);
                break;

            case "Ring":
                GetComponentInChildren<Pistol>().IncreaseDamage(damageIncrease);
                break;

            case "Lucky Coin":
                GetComponent<CoinPickUp>().SetCoinMultiplier(increaseMultiplier);
                break;

            case "Deadly Bullet":
                GetComponentInChildren<Pistol>().SetSpecialBullet(deadlyBullet);
                break;

            case "Fire Bullet":
                GetComponentInChildren<Pistol>().SetSpecialBullet(fireBullet);
                break;

            case "Poison Bullet":
                GetComponentInChildren<Pistol>().SetSpecialBullet(poisonBullet);
                break;

            case "Grenade":
                abilityPosition.gameObject.SetActive(true);
                Instantiate(grenadeAbility, abilityPosition.position, abilityPosition.rotation, abilityPosition);
                break;

            case "Vines":
                abilityPosition.gameObject.SetActive(true);
                Instantiate(vinesAbility, abilityPosition.position, abilityPosition.rotation, abilityPosition);
                break;

            case "Vortex Staff":
                abilityPosition.gameObject.SetActive(true);
                Instantiate(vortexAbility, abilityPosition.position, abilityPosition.rotation, abilityPosition);
                break;

            case "Diamond":
                StartCoroutine(GetComponent<PlayerHealth>().Invincibility());
                break;

            case "Potion of Healing":
                var playerHealth = GetComponent<PlayerHealth>();
                playerHealth.Heal(playerHealth.GetMaxHealth() - playerHealth.GetCurrentHealth());
                break;
        }
    }
}

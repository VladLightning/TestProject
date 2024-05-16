using System.Collections;
using UnityEngine;

public class MerchantSpawn : MonoBehaviour
{
    public float startSpawnChance;
    public float currentSpawnChance;
    public float chanceIncrease;

    public GameObject merchant;
    public GameObject particles;
    public ItemsRandomizer itemsRandomizer;

    private void Start()
    {
        currentSpawnChance = startSpawnChance;
    }

    public void StartTrySpawnMerchant(Vector3 spawnPosition)
    {
        StartCoroutine(TrySpawnMerchant(spawnPosition));
    }

    public IEnumerator TrySpawnMerchant(Vector3 spawnPosition)
    {
        if(Random.value <= currentSpawnChance) 
        {
            Instantiate(particles, spawnPosition, particles.transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(merchant, spawnPosition, transform.rotation);
            itemsRandomizer.SetupShop();
            currentSpawnChance = startSpawnChance;
            yield break;
        }
        currentSpawnChance += chanceIncrease;
    }

}

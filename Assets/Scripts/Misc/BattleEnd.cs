using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public int enemiesAmount;

    public MerchantSpawn merchantSpawn;
    public BackgroundMusic backgroundMusic;
    public GameObject[] objectsToDeactivate;

    private void OnDisable()
    {
        backgroundMusic.SetMusicToDefault();
        for (int i = 0; i < objectsToDeactivate.Length; i++)
        {
            objectsToDeactivate[i].SetActive(false);
        }
        merchantSpawn.StartTrySpawnMerchant(transform.position);
    }

    public void SetEnemyAmount(int enemyCount)
    {
        enemiesAmount = enemyCount;
    }

    public void IncreaseEnemyAmount(int increaseAmount)
    {
        enemiesAmount += increaseAmount;
    }

    public void DecreaseEnemyAmount()
    {
        enemiesAmount--;
        if (enemiesAmount <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        backgroundMusic.SetMusicToDefault();
        for(int i = 0; i < objectsToDeactivate.Length; i++)
        {
            objectsToDeactivate[i].SetActive(false);
        }
        merchantSpawn.StartTrySpawnMerchant(transform.position);
    }
}

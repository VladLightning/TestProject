using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public int enemiesAmount;

    public MerchantSpawn merchantSpawn;
    public BackgroundMusic backgroundMusic;
    public GameObject objectToDeactivate;

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
        objectToDeactivate.SetActive(false);
        merchantSpawn.StartTrySpawnMerchant(transform.position);
    }
}

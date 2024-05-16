using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] enemiesToSpawn;
    public GameObject particles;

    public int spawnLimit;
    public int spawnCount;
    public float spawnDelay;

    public BattleEnd battleEnd;

    public void Start()
    {
        StartCoroutine(SpawnEnemy());
        battleEnd = GetComponent<BattleEnd>();
        battleEnd.SetEnemyAmount(spawnLimit);
    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        while(spawnCount < spawnLimit)
        {
            GameObject enemyToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
            Vector3 spawnPosition = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
            Instantiate(particles, spawnPosition, particles.transform.rotation, transform);

            yield return new WaitForSeconds(0.6f);

            GameObject enemy = Instantiate(enemyToSpawn, spawnPosition, transform.rotation, transform);

            enemy.SetActive(true);

            if (enemy.TryGetComponent<EnemySplit>(out var enemySplit))
            {
                battleEnd.IncreaseEnemyAmount(enemySplit.GetFragmentsAmount());
            }

            spawnCount++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}

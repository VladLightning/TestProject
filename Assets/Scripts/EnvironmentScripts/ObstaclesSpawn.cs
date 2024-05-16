using System.Collections;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    public Transform objectToDisturb;
    public GameObject obstacle;

    public float[] posibleAngle;

    public float spawnDelay;

    public bool isActive;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    public void StartSpawnObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    public IEnumerator SpawnObstacles()
    {
        while (isActive)
        {
            float angle = posibleAngle[Random.Range(0, posibleAngle.Length)];

            Instantiate(obstacle, objectToDisturb.position, Quaternion.Euler(0,0,angle));
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SetIsActive(bool value)
    {
        isActive = value;
    }
}

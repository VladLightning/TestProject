using System.Collections;
using UnityEngine;

public class SpecialSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objectsToSpawn;
    public GameObject particles;

    public bool isActive;
    public float spawnDelay;

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            StartCoroutine(ExecuteSpawn());
        }
    }

    public void StartExecuteSpawn()
    {
        StartCoroutine(ExecuteSpawn());
    }

    public IEnumerator ExecuteSpawn()
    {
        isActive = true;
        while (isActive)
        {
            StartCoroutine(Spawn());
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public IEnumerator Spawn()
    {
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
        Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Instantiate(particles, spawnPosition, particles.transform.rotation, transform);
        yield return new WaitForSeconds(0.6f);
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, transform.rotation, transform);
        spawnedObject.SetActive(true);
    }

    public void SetIsActive(bool value)
    {
        isActive = value;
    }
}

using UnityEngine;

public class BoxReceiver : MonoBehaviour
{
    public Transform[] receiverSpawnPoints;
    public Transform[] boxSpawnPoints;

    public GameObject box;
    public GameObject spawner;

    public EnemyHealth bossHealth;
    public ObstaclesSpawn obstaclesSpawn;
    public FollowTarget bossFollowTarget;
    public Mage mage;

    private void Start()
    {
        box = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            BossActivate();
        }
    }

    public void BossActivate()
    {
        bossFollowTarget.enabled = true;
        mage.enabled = true;

        obstaclesSpawn.SetIsActive(false);
        bossHealth.SetIsInvincible(false);
        spawner.GetComponent<SpecialSpawn>().SetIsActive(false);

        mage.StartCountdown();

        gameObject.SetActive(false);
        Relocate();
    }

    public void Relocate()
    {
        transform.position = receiverSpawnPoints[Random.Range(0, receiverSpawnPoints.Length)].position;
        box.transform.position = boxSpawnPoints[Random.Range(0, boxSpawnPoints.Length)].position;
    }
}

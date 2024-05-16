using UnityEngine;

public class BossAbility : MonoBehaviour
{
    public GameObject cloneToMake;
    public GameObject spawnParticles;
    public Transform[] teleportPoints;

    public GameObject[] clones;
    public EnemyHealth bossHealth;

    public int clonesAmount;
    public int currentClonesAmount;

    private void Start()
    {
        bossHealth = GetComponent<EnemyHealth>();
        clones = new GameObject[clonesAmount];
    }

    public void Teleport()
    {
        transform.position = teleportPoints[Random.Range(0, teleportPoints.Length)].position;
    }

    public void CloneSelf()
    {            
        for (int i = 0; i < clonesAmount; i++)
        {
            int randomIndex = Random.Range(0, teleportPoints.Length);
            clones[i] = Instantiate(cloneToMake, teleportPoints[randomIndex].position, teleportPoints[randomIndex].rotation, teleportPoints[randomIndex]);
            Instantiate(spawnParticles, clones[i].transform.position, clones[i].transform.rotation, clones[i].transform);
            clones[i].GetComponent<Clone>().SetBossAbility(this);
        }
        currentClonesAmount = clonesAmount;
    }

    public void DecreaseClonesAmount()
    {
        currentClonesAmount--;
        if(currentClonesAmount <= 0)
        {
            bossHealth.SetIsInvincible(false);
        }
    }
}

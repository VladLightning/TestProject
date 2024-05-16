using UnityEngine;

public class EnemySplit : MonoBehaviour
{
    public GameObject fragmentToSpawn;
    public int fragmentsAmount;
    public float health;

    public int GetFragmentsAmount()
    {
        return fragmentsAmount;
    }

    public void Split()
    {
        for (int i = 0; i < fragmentsAmount; i++)
        {
            GameObject fragment = Instantiate(fragmentToSpawn, transform.position, transform.rotation, transform.parent);
            fragment.SetActive(true);
        }
    }
}

using UnityEngine;

public class FinishBattle : MonoBehaviour
{
    public GameObject[] objectsToDestroy;

    private void OnDisable()
    {
        for (int i = 0; i < objectsToDestroy.Length; i++)
        {
            Destroy(objectsToDestroy[i]);
        }
    }
}

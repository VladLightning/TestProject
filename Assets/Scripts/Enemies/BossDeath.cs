using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public GameObject objectToSpawn;
    public RectTransform gameCanvas;

    public void FinishLevel()
    {
        Instantiate(objectToSpawn,gameCanvas);
    }
}

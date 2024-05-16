using UnityEngine;

public class BoundaryActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public Transform[] entrencePositions;
    public int roomIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectsToActivate[roomIndex].SetActive(true);
            transform.position = entrencePositions[roomIndex].position;
            roomIndex++;
        }
    }
}

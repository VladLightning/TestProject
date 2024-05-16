using Cinemachine;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCamera = collision.GetComponent<PlayerStatuses>().GetVirtualCamera();
            playerCamera.Priority += 2;
            SetNewCameraPosition(transform, transform.localScale.y / 2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCamera.Priority -= 2;
        }
    }

    public void SetNewCameraPosition(Transform position, float lensSize)
    {
        playerCamera.LookAt = position;
        playerCamera.Follow = position;
        playerCamera.m_Lens.OrthographicSize = lensSize;
    }
}

using Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera battleCamera;
    public Transform[] entrancePositions;
    public Transform[] cameraLookPoints;
    public Transform movingLookPoint;
    public CameraSwitch cameraSwitch;

    public enum BattleRooms
    {
        Small = 0,
        Medium = 1,
        Large = 2,
    }
    public BattleRooms[] battleRoomSize;
    public int battleRoomIndex;
    public float cameraSpeed;
    public float updateDisableDelay;

    public float cameraSizeSmall;
    public float cameraSizeMedium;
    public float cameraSizeLarge;

    public void Update()
    {
        if(battleRoomIndex > 0)
        {
            movingLookPoint.position = Vector2.MoveTowards(movingLookPoint.position, cameraLookPoints[battleRoomIndex - 1].position, cameraSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeCamera();
        }
    }

    public void ChangeCamera()
    {
        cameraSwitch.enabled = true;
        switch (battleRoomSize[battleRoomIndex])
        {
            case BattleRooms.Small:
                battleCamera.m_Lens.OrthographicSize = cameraSizeSmall;
                break;
            case BattleRooms.Medium:
                battleCamera.m_Lens.OrthographicSize = cameraSizeMedium;
                break;
            case BattleRooms.Large:
                battleCamera.m_Lens.OrthographicSize = cameraSizeLarge;
                break;
        }
        transform.position = entrancePositions[battleRoomIndex].position;
        battleRoomIndex++;
        Invoke(nameof(DisableUpdate), updateDisableDelay);
    }

    public void DisableUpdate()
    {
        cameraSwitch.enabled = false; 
    }
}

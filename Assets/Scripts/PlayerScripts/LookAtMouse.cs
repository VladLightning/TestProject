using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;

    private void Start()
    {
        player = transform.parent;
    }
    public void Update()
    {
        PointTowardCursor();
    }

    public void PointTowardCursor()
    {
        Vector3 difference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        if (rotation > 90 || rotation < -90)
        {
            player.localScale = new Vector3(-Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
            transform.rotation = Quaternion.Euler(180, 0, -rotation);
        }
        else
        {
            player.localScale = new Vector3(Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
        }

        transform.localScale = player.localScale.x < 0 ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z) 
                                                       : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}

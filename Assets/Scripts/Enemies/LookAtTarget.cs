using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer lookingObject;

    public void Update()
    {
        if(transform.position.x < target.position.x)
        {
            LookAt(false);
        }
        else
        {
            LookAt(true);
        }
    }

    public void LookAt(bool value)
    {
        transform.right = target.position - transform.position;
        lookingObject.flipX = value;
        lookingObject.flipY = value;
    }
}

using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float defaultStoppingDistance;
    public float stoppingDistance;
    public float defaultSpeed;
    public float currentSpeed;

    private void Start()
    {
        SetSpeedToDefault();
        SetStoppingDistanceToDefault();
    }

    public void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
        }
        transform.localScale = (transform.position.x > target.position.x) ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z) 
                                                                          : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void SetSpeedToDefault()
    {
       currentSpeed = defaultSpeed;
    }

    public void SetStoppingDistanceToDefault()
    {
        stoppingDistance = defaultStoppingDistance;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void SetStoppingDistance(float newDistance)
    {
        stoppingDistance = newDistance;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public Transform GetTarget()
    {
        return target;
    }

    public float GetStoppingDistance()
    {
        return stoppingDistance;
    }
}

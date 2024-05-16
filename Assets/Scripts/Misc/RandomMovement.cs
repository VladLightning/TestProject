using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movementInterval;
    public float speed;
    public float distance;

    public Vector2 direction;
    public Vector2 target;

    private void Start()
    {
        StartCoroutine(RandomizedMovement());
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public IEnumerator RandomizedMovement()
    {
        while (true)
        {          
            target = FindDestination();

            transform.localScale = (direction.x < 0) ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z)
                                                     : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
          
            yield return new WaitForSeconds(movementInterval);
        }
    }

    public Vector2 FindDestination()
    {
        for(int tryToFindPath = 0; tryToFindPath < 10; tryToFindPath++)
        {
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            distance = Random.Range(3, 7);

            RaycastHit2D destinationPoint = Physics2D.Raycast(transform.position, direction, distance + 2, LayerMask.GetMask("Obstacle"));

            if (destinationPoint.collider == null)
            {
                return (Vector2)transform.position + direction * distance;
            }
        }
        return transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction * distance);
    }
}

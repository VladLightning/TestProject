using System.Collections;
using UnityEngine;

public class BlindnessAreaCast : MonoBehaviour
{
    public GameObject blindnessArea;

    public Animator animator;
    public Rigidbody2D target;
    public FollowTarget followTarget;
    public Vector2 areaOffset;

    public float castInterval;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        followTarget = GetComponentInParent<FollowTarget>();
        StartCoroutine(SpawnBlindnessArea());
    }

    public IEnumerator SpawnBlindnessArea()
    {
        while (true)
        {
            animator.Play("Attack");

            followTarget.SetSpeed(0);
            yield return new WaitForSeconds(1.1f);
            
            areaOffset = (Vector2)target.transform.position + target.velocity / 2;
            Instantiate(blindnessArea, areaOffset, transform.rotation);

            yield return new WaitForSeconds(0.4f);
            followTarget.SetSpeedToDefault();

            yield return new WaitForSeconds(castInterval);
        }
    }
}

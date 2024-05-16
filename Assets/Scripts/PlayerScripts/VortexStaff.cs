using System.Collections;
using UnityEngine;

public class VortexStaff : MonoBehaviour
{

    public float duration;
    public float activationDelay;

    public PointEffector2D effector;

    private void Start()
    {
        StartCoroutine(ActivateStaff());
    }

    public IEnumerator ActivateStaff()
    {
        yield return new WaitForSeconds(activationDelay);
        effector.enabled = true;
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}

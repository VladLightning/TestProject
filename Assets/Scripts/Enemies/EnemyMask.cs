using System.Collections;
using UnityEngine;

public class EnemyMask : MonoBehaviour
{
    public Collider2D enemyCollider;
    public SpriteMask mask;

    public float invincibilityDuration;

    private void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        mask = GetComponentInChildren<SpriteMask>();        
    }

    public void StartDisableMask()
    {
        StartCoroutine(DisableMask());
    }

    public IEnumerator DisableMask()
    {
        enemyCollider.enabled = false;
        mask.enabled = false;

        yield return new WaitForSeconds(invincibilityDuration);

        enemyCollider.enabled = true;
        mask.enabled = true;
    }
}

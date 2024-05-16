using System.Collections;
using UnityEngine;

public class Glimmer : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;

    public float invisibilityTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartGlimmering();
    }

    public void StartGlimmering()
    {
        StartCoroutine(Glimmering());
    }

    public IEnumerator Glimmering()
    {
        Color color = spriteRenderer.color;
        while (true)
        {
            while (color.a > 0)
            {
                color.a -= 0.05f;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(invisibilityTime);
            while (color.a < 0.6f)
            {
                color.a += 0.05f;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

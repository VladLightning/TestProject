using System.Collections;
using UnityEngine;

public class Vines : MonoBehaviour
{
    public float remainingLifeTime;
    public float duration;

    public SpriteRenderer image;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        remainingLifeTime = duration-1;
        StartCoroutine(FadeOut());
        Destroy(gameObject, duration);
    }

    private void Update()
    {
        remainingLifeTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(SlowDownEnemies(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<FollowTarget>().SetSpeedToDefault();
        }
    }

    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(duration-1);
        Color imageColor = image.color;
        while (image.color.a > 0)
        {
            imageColor.a -= 0.01f;
            image.color = imageColor;
            yield return new WaitForSeconds(1 / 120);
        }    
    }

    public IEnumerator SlowDownEnemies(Collider2D collision)
    {
        if(remainingLifeTime <= 0)
        {
            yield break;
        }
        var followTarget = collision.GetComponent<FollowTarget>();
        
        followTarget.SetSpeed(0);
        yield return new WaitForSeconds(remainingLifeTime);
        followTarget.SetSpeedToDefault();
    }
}

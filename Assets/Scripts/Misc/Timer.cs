using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;

    public void StartTimer()
    {
        Destroy(gameObject, time);
    }

    public float GetTime()
    {
        return time;
    }
}

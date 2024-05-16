using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

    public float timer;
    
    private void Start()
    {
        Destroy(gameObject, timer);
    }
}

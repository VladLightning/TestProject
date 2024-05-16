using UnityEngine;

public class UIElementDestroy : MonoBehaviour
{

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ActivateButtons : MonoBehaviour
{

    private void Start()
    {
        for(int i = 2; i < transform.childCount; i++)
        {
            if (PlayerPrefs.GetInt("levelsCompleted") >= i)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
    }
}

using UnityEngine;

public class Levels : MonoBehaviour
{
    public LoadLevel[] loadLevel;

    private void OnValidate()
    {
        loadLevel = GetComponentsInChildren<LoadLevel>();

        for (int i = 0; i < loadLevel.Length; i++)
        {
            loadLevel[i].SetIndex(i+1);
            transform.GetChild(i+1).name = $"Level{i+1}";
        }
    }
}

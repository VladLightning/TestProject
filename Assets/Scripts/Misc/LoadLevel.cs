using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public TMP_Text levelText;
    public int levelIndex;

    public void Load()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void SetIndex(int setIndex)
    {
        levelIndex = setIndex;
        levelText.text = levelIndex.ToString();
    }
}

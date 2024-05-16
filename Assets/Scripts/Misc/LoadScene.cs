using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string levelName;
    public void Load()
    {
        SceneManager.LoadScene(levelName);
    }
}

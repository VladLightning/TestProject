using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public int delay;
    public float fadeLevel;
    public float fadeTime;

    public void Start()
    {
        Image winPanel = GetComponent<Image>();
        winPanel.CrossFadeAlpha(fadeLevel, fadeTime, true);

        SlowDownTime();
    }

    public void WinGame()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (PlayerPrefs.GetInt("levelsCompleted") < levelIndex && SceneManager.GetActiveScene().name != "Tutorial")
        {
            PlayerPrefs.SetInt("levelsCompleted", levelIndex);
        }
        SceneManager.LoadScene("LevelSelection");
    }

    public async void SlowDownTime()
    {
        while (Time.timeScale >= 0.1f)
        {
            Time.timeScale -= 0.1f;
            await Task.Delay(delay);
        }
        Time.timeScale = 1;
        WinGame();
    }
}

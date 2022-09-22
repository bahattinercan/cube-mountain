using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGameButton()
    {
        int level = PlayerPrefs.GetInt(EPlayerPrefs.currentLevel.ToString());
        SceneManager.LoadScene("Level" + level);
    }
}
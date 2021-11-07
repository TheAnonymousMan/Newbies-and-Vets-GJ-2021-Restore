using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(Levels.stage[0]);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(Levels.menu);
    }

    public void ResumeGame(GameObject pauseMenu)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Flags.isPaused = false;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

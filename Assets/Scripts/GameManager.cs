using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject deathMenu;

    [SerializeField]
    private GameObject player;

    void Awake()
    {
        // don't destroy game manager on load
        DontDestroyOnLoad(gameObject);

        Levels.numOfLevels = Levels.stage.Length;
        Counters.lives = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        Flags.isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flags.isPlayerAlive)
        {
            PlayerDeath();
        }

        if (Flags.isStageClear)
        {
            LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Flags.isPlayerAlive)
        {
            Debug.Log("Escape Pressed");
            HandlePause();
        }
    }

    void PlayerDeath()
    {
        Counters.lives -= 1;

        if (Counters.lives < 0)
        {
            GameOver();
        }
        else
        {
            Destroy(player);
            deathMenu.SetActive(true);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(Levels.over);
    }

    void LoadNextLevel()
    {
        Scene currentScene;
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex + 1 != Levels.numOfLevels)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(Levels.complete);
        }
    }

    void HandlePause()
    {
        if (!Flags.isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Flags.isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Flags.isPaused = false;
        }
    }
}

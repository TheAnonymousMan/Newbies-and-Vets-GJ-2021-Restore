using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        // don't destroy game manager on load
        DontDestroyOnLoad(gameObject);
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
            GameOver();
        }

        if (Flags.isStageClear)
        {
            LoadNextLevel();
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
}

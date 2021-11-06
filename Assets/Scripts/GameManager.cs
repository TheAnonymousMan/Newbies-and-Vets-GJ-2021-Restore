using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isLevelComplete;

    public const int numOfLevels = 5;

    public string[] levels;

    public string MenuScene;
    public string GameOverScene;

    public string GameCompleteScene;

    void Awake()
    {
        // don't destroy game manager on load
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        FlagHolder.isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!FlagHolder.isPlayerAlive)
        {
            GameOver();
        }

        if(isLevelComplete)
        {
            LoadNextLevel();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(GameOverScene);
    }

    void LoadNextLevel()
    {
        Scene currentScene;
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.buildIndex != numOfLevels)
            SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}

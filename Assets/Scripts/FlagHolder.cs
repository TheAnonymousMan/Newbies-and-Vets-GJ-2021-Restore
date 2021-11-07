
public static class Flags
{
    public static bool isPlayerAlive = true;

    public static bool isStageClear = false;

    public static bool isPaused = false;
}

// Storing the level names for easy access
public static class Levels
{
    public static string[] stage = {
        "Level0"
    };

    public static string menu = "MenuScene";

    public static string complete = "GameCompleteScene";

    public static string over = "GameOverScene";

    public static int numOfLevels = 5;
}

public static class Counters
{
    public static int maxEnemiesOnBoard = 5;

    public static int enemiesOnBoard = 0;

    public static int lives = 3;
}

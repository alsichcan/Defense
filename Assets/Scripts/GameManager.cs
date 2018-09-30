using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;
    public static bool GameIsOver;

    public static string GameMode;
    public string defaultGameMode = "Extreme";

    [Header("Round")]
    public static int Rounds;

    public static float prepareTime;
    public float defaultPrepareTime = 6f;

    public static float roundTime;
    public float defaultRoundTime = 61f;

    public static float currentTime;


    [Header("Enemy")]
    public static int EnemyPerRound;
    public int defaultEnemyPerRound = 40;

    public static int EnemyCount;
    public int startEnemyCount = 0;

    public static int MaxEnemyCount;
    public int defaultMaxEnemyCount = 100;

    [Header("Boss")]
    public static bool isBossAlive;

    public static int BossHealthPoint;
    public int startBossHealthPoint = 0;

    public static int BossMaxHealthPoint;
    public int defaultBossMaxHealthPoint = 10000;
    

    private void Start()
    {
        GameIsOver = false;
        GameMode = defaultGameMode;

        Rounds = 0;
        prepareTime = defaultPrepareTime;
        roundTime = defaultRoundTime;
        currentTime = defaultPrepareTime;

        EnemyPerRound = defaultEnemyPerRound;
        EnemyCount = startEnemyCount;
        MaxEnemyCount = defaultMaxEnemyCount;

        BossHealthPoint = startBossHealthPoint;
        BossMaxHealthPoint = defaultBossMaxHealthPoint;
        isBossAlive = false;
    }

    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;

		if (EnemyCount >= MaxEnemyCount)
        {
            GameOver();
        }
    }

    void GameClear()
    {
       // TODO - Implement
    }

    

    void GameOver()
    {
        GameIsOver = true;

        // Game Over UI를 활성화한다.
        gameOverUI.SetActive(true);
    }
}


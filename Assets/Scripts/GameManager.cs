using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;
    public static int MaxEnemyCount;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
        PlayerStats.Rounds = 0;
        MaxEnemyCount = 100;
    }

    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;

		if (PlayerStats.EnemyCount >= MaxEnemyCount)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;

        // Game Over UI를 활성화한다.
        gameOverUI.SetActive(true);
    }
}

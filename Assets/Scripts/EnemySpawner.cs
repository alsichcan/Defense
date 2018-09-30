using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class EnemySpawner : MonoBehaviour {

    public Round[] rounds;
    public Transform spawnPoint;

    private void Update()
    {
        if (GameManager.currentTime <= 0f)
        {
            GameManager.currentTime = GameManager.roundTime;
            StartCoroutine(SpawnRound());
        }
        GameManager.currentTime -= Time.deltaTime;
    }

    IEnumerator SpawnRound()
    {
        // 다음 라운드 시작
        GameManager.Rounds++;
        
        // 라운드에 해당하는 Enemy 가져옴
        Round round = rounds[GameManager.Rounds];

        // 1Round당 시간에
        for (int i = 0; i < GameManager.roundTime; i++)
        {
            GameManager.currentTime -= Time.deltaTime;
            
            // 처음 1Round당 Enemy 수(40마리 = 40초)만큼 Enemy 생성
            // Enemy 소환 사이사이의 시간 (1초)만큼 기다림
            SpawnEnemy(round.enemy);
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        GameManager.EnemyCount++;
    }
}

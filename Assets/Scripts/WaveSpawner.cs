using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class WaveSpawner : MonoBehaviour {

    public Round[] rounds;

    public Transform spawnPoint;


    // Round 시작 전 5초
    private float countdown = 6f;

    public Text waveCountdownText;

    // 1Round당 시간
    private float roundTime = 61f;

    // Wave당 소환되는 Enemy 수 
    private int roundWave = 40;

    private void Update()
    {
        if (countdown <= 0f)
        {
            countdown = roundTime;
            StartCoroutine(SpawnWave());
        }

        TimeUpdate();

    }

    IEnumerator SpawnWave()
    {
        // 다음 라운드 시작
        PlayerStats.Rounds++;

        if (PlayerStats.Rounds == rounds.Length)
        {
            Debug.Log("Game Clear!");
            this.enabled = false;
            yield break;
        }

        Round round = rounds[PlayerStats.Rounds];

        // 1Round당 시간에
        for (int i = 0; i < roundWave; i++)
        {
            TimeUpdate();
            
            // 처음 1Round당 Enemy 수(40마리 = 40초)만큼 Enemy 생성
            // Enemy 소환 사이사이의 시간 (1초)만큼 기다림
            SpawnEnemy(round.enemy);
            yield return new WaitForSeconds(1f);
           
        }



    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        PlayerStats.EnemyCount++;
    }

    void TimeUpdate()
    {
        countdown -= Time.deltaTime;

        // 전광판에 표시
        if (PlayerStats.Rounds < 10)
        {
            if (countdown < 10f) waveCountdownText.text = "Lv." + "0" + PlayerStats.Rounds.ToString() + " " + "0" + Mathf.Floor(countdown).ToString() + "'";
            else waveCountdownText.text = "Lv." + "0" + PlayerStats.Rounds.ToString() + " " + Mathf.Floor(countdown).ToString() + "'";

        }
        else
        {
            if (countdown < 10f) waveCountdownText.text = "Lv." + PlayerStats.Rounds.ToString() + " " + "0" + Mathf.Floor(countdown).ToString() + "'";
            else waveCountdownText.text = "Lv." + PlayerStats.Rounds.ToString() + " " + Mathf.Floor(countdown).ToString() + "'";
        }
    }
}

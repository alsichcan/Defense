using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Rounds;

    public static int Gold;
    public int startGold = 10;

    public static int Lumber;
    public int startLumber = 5;

    public static int EnemyCount;
    public int startEnemyCount= 0;

    public static int BossHealthPoint;
    public int startBossHealthPoint = 0;

    private void Start()
    {
        Gold = startGold;
        Lumber = startLumber;
        EnemyCount = startEnemyCount;
        BossHealthPoint = startBossHealthPoint;

        Rounds = 0;
    }


}

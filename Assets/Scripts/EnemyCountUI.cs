using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUI : MonoBehaviour {

    public Text enemyCountText;

    // Update is called once per frame
    void Update()
    {
        enemyCountText.text = "Enemy " + PlayerStats.EnemyCount.ToString();
    }
    
}

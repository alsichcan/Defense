using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour {

    public Image BossHPBar;
    public Text BossHPText;

	// Update is called once per frame
	void Update () {

        if (!GameManager.isBossAlive)
        {
            BossHPText.text = "";
            BossHPBar.fillAmount = 0;
        }
        else
        {
            float BossHPRatio = (float) GameManager.BossHealthPoint / GameManager.BossMaxHealthPoint;
            BossHPText.text = (BossHPRatio * 100).ToString() + "%";
            BossHPBar.fillAmount = BossHPRatio;

        }
    }
}

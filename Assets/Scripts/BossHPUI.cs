using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour {

    public Text BossHPText;

	// Update is called once per frame
	void Update () {
        BossHPText.text = "Boss " + PlayerStats.BossHealthPoint.ToString() +"%";
	}
}

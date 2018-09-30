using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour {

    [Header("UnitInfo")]
    public string unitName;
    public string unitClass;
    public Sprite unitPortrait;
    public Sprite unitIcon;

    [Header("UnitStats")]
    public int startLevel = 0;
    public float startAttackDamage;
    public float startAttackSpeed = 1f;
    public float startAttackRange;

    public bool useRangeAttack = false;
    public GameObject projectilePrefab;

    public bool useMana = false;
    public float startMana = 0;
      
    [HideInInspector]
    public int unitLevel;
    [HideInInspector]
    public float unitMana, attackDamage, attackSpeed, attackRange;
    [HideInInspector]
    public ArrayList unitStatus;

    /* TODO : implement commands
    [Header("BasicCommands")]

    [Header("MixCommands")]

    [Header("Skills")]
    */
    

    private void Start()
    {
        unitLevel = startLevel;
        unitMana = startMana;
        attackDamage = startAttackDamage;
        attackSpeed = startAttackSpeed;
        attackRange = startAttackRange;
        unitStatus = new ArrayList();
    }

}


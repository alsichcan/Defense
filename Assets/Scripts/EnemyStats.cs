using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    
    [Header("Enemy Stats")]
    public float startSpeed = 10f;
    public float startHealth = 100;
    public float health;
    public int armor;
    public float speed;
    public int goldDrop;

    [Header("Unity Stuff")]
    public Image healthBar;


    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        PlayerStats.EnemyCount--;
        PlayerStats.Gold += goldDrop;
    }
}

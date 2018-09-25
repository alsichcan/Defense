using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    [Header("Enemy Stats")]
    public int health;
    public int armor;
    public float speed = 10f;
    public int goldDrop;
    
    public void TakeDamage (int damage)
    {
        health -= damage;

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

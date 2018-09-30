using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    private Transform target;
    private EnemyStats targetEnemy;

    // 연속으로 공격하도록
    private float attackCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform attackPoint;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    
    /*
	// Use this for initialization
	void Start () {
        // 시작하자마자 (시작 0f후) UpdateTarget()을 0.5f마다 실행
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // 최단거리의 Enemy를 새로 발견하면
            if (distanceToEnemy < shortestDistance)
            {
                // 해당 Enemy를 가장 가까운 Enemy로 설정
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyStats>();
        }
        else
        {
            target = null;
        }
    }


	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        LockOnTarget();

        if (attackCountdown <= 0f)
            {
            if (useRangeAttack) RangeAttack();
            else MeleeAttack();
            attackCountdown = 1f / attackRate;
            }

        attackCountdown -= Time.deltaTime;
 


    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        // 기존의 각도에서 새로운 각도로 1초에 turnSpeed만큼회전
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void RangeAttack()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.SetDamage(damage);

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void MeleeAttack()
    {
        if(targetEnemy != null)
        {
            targetEnemy.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    */
}

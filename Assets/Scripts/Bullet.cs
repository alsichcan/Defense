using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    // 총알 데미지
    private int damage;

    [Header("Attribute (default)")]
    // 총알이 날라가는 속도
    public float speed = 70f;

    [Header("Explosive")]
    public bool isExplosive = false;
    // 총알 공격 범위
    public float explosionRadius;
    public GameObject impactEffect;


    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // 목표물에 다다랐을 때
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // 목표물에 다다르지 못했을 때
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        // 발사체가 목표물에게 방향이 향하도록
        transform.LookAt(target);
  	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (isExplosive)
        {
            Explode();
        }else
        {
            Damage(target);
        }

        Destroy(gameObject);

    }


    void Explode()
    {
        // Bullet의 위치 기준 폭발 범위안에 있는 Colliders들을 탐지
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        EnemyStats e = enemy.GetComponent<EnemyStats>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

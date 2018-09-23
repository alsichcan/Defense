using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    // 총알이 날라가는 속도
    public float speed = 70f;
    public GameObject impactEffect;

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
  	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);

    }
}

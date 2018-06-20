using UnityEngine;

public class MoveBullet : MonoBehaviour {

    private Transform target;
    public float blastRadius = 0;
    public float speed = 70f;
    public GameObject particleEffect;

    public void Seek(Transform givenTarget)
    {
        target = givenTarget;
    }

	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime; 

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    void HitTarget()
    {
        GameObject effect = (GameObject) Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        
        if (blastRadius != 0)
        {
            Explode();
        } else
        {
            Damage(target);
            PlayerStats.Money += Enemy.killValue;
            Debug.Log(PlayerStats.Money);
        }

        Destroy(gameObject);
        
        
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
                PlayerStats.Money += 10;       /////////This will become problematic when multiple killValues are involved
            }
        }
        Debug.Log(PlayerStats.Money);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);

    }
}

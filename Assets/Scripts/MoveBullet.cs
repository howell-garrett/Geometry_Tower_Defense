using UnityEngine;

public class MoveBullet : MonoBehaviour {

    private Transform target;
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
	}

    void HitTarget()
    {
        GameObject effect = (GameObject) Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}

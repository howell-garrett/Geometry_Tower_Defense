using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public static int killValue = 10;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    { 
        if (target == null)
        {
            Debug.Log("Hel");
            target = Waypoints.points[0];
        }  
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
       

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.points.Length - 1)
        {
            
            Destroy(gameObject);
            return;
        
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
}

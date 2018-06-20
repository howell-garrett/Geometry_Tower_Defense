using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartWave : MonoBehaviour {
    private int waveCount = 0;
    public Transform spawnPoint;
    public Transform enemyPrefab;
    private bool waveHasStarted = false;
    private Renderer rend;



    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (!waveHasStarted)
        {
            waveHasStarted = true;
            StartCoroutine(SpawnWave());
           
        }
    }




    IEnumerator SpawnWave()
    {

        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.2f);
        }

        waveHasStarted = false;


    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void OnMouseEnter()
    {


        rend.material.color = Color.white;
    }
}

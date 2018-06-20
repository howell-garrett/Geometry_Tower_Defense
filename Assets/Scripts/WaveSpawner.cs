
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public float timeBetweenWaves = 4f;
    private float countdown = 2f;

    private int waveCount = 0;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
       

    }

    IEnumerator SpawnWave()
    {

        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.2f);
        }
       
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}


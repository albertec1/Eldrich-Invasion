
using System.Security.Cryptography;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnArea;

    public float waveCooldown = 10f;

    private float countdown = 5f;
    private int waveNumer = 1;


    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            
            countdown = waveCooldown;
        }

        countdown -= Time.deltaTime;
        
    }

    void SpawnWave()
    {
        Debug.Log("Wave incoming");

        for (int i = 0; i<waveNumer; i++)
        {
            SpawnEnemy();
        }

        waveNumer++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnArea.position, spawnArea.rotation);
    }
}


using System.Security.Cryptography;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnArea;
    public float waveCooldown = 10f;
    public float Radius = 1f;
    public Vector3 center;
    public Vector3 size;

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
        //enemyPrefab.position
        Vector3 randomPos = new Vector3(-10.6f, 1.5f, 121) + new Vector3(Random.Range(-2, 2), 0, Random.Range(-7, 7));
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(center, size);
    }
}

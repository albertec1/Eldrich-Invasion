
using System.Collections;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size;

    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public int count;
        public int count2;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }


    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length -1 )
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyAlive()
    {

        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("Wave completed AAAAAAAAAAAAAAAAAAAAAA");
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/ _wave.rate);    
        }
        for (int i = 0; i < _wave.count2; i++)
        {
            SpawnEnemy(_wave.enemy2);
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Vector3 randomPos = new Vector3(-10.6f, 1.5f, 121) + new Vector3(Random.Range(-2, 2), 0, Random.Range(-7, 7));
        Instantiate(_enemy, randomPos, Quaternion.identity);
    }

}

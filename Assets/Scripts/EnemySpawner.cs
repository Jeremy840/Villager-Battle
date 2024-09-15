using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;

    public TMP_Text timerBetweenWaves;

    public int maxNumOfWaves = 50;
    public int currentWave = 0;

    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    private float searchCountdown = 1f;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;

    private SpawnState state = SpawnState.COUNTING;

    public ParticleSystem ParticleSystem;

    void Start()
    {
        nextWave = MainManager.Instance.nextWave;
        //waveCountdown = timeBetweenWaves;
        int wavesCountdownInt = (int)waveCountdown;
        timerBetweenWaves.text = wavesCountdownInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        teleporter tele = GameObject.FindGameObjectWithTag("teleporter").GetComponent<teleporter>();
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                tele.isActive = true;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                tele.isActive = false;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            int wavesCountdownInt = (int)waveCountdown;
            timerBetweenWaves.text = wavesCountdownInt.ToString();
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        print("wave starting");
        ParticleSystem.Stop();
        state = SpawnState.SPAWNING;
        

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;
        ParticleSystem.Play();
        yield break;
    }

    void WaveCompleted()
    {
        print("wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            SceneManager.LoadScene(4);
        }
        nextWave++;
        MainManager.Instance.nextWave = nextWave;
    }

    void SpawnEnemy (Transform enemy)
    {
        // Spawn enemy
        Instantiate(enemy, transform.position, Quaternion.identity);
        print("Spawing enemy" + enemy.name);
    }
}

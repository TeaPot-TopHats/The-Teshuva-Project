using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;
    public Transform enemy;
    public int count;
    public float rate;

} // end of Wave Class

public enum SpawnState
{
    spawning,
    waiting,
    counting
}// end of enum
public class WaveSpawner : MonoBehaviour
{

    public SpawnState spawnState = SpawnState.counting;

    public Wave[] waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public Transform[] spawnPoints;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points are found");
        }
    }// end of start

    /*wa
     * 
     */
    void Update()
    {
        if (spawnState == SpawnState.waiting)
        {
            // check if enemy are still alive
            if (!EnemyIsAlive())
            {

                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (spawnState != SpawnState.spawning)
            {
                Debug.Log("Spawning wave, corouting start");
                // spawn wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else // a check for the countdown to go down correctlly
        {
            waveCountdown -= Time.deltaTime;
        }
    } // end of update

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        spawnState = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        /*
         * Change what heppend when we finish all waved here
         * now it just reset the wave to 0 so it looping
         */
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All wave are completed!!");
        }
        else
        {
            nextWave++;
        }
    } // end of wave completed
    /*
     * 
     */
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown= 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // or GameObject.FindObjectWithTag("enemy") == null
            {
                Debug.Log("No enemy found, begin next wave");
                return false;
            }
        }// end of if search count down
        
        return true;
    } // end of bool Enemey is alive

    /*
     * 
     */
    IEnumerator SpawnWave (Wave _wave)
    {
        spawnState= SpawnState.spawning;
        Debug.Log("spawning wave," + _wave.name);
        for( int i = 0; i < _wave.count; i++)
        {
            Debug.Log("Spawning Enemy");
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        spawnState= SpawnState.waiting;
        yield break;

    }// end of spawnwave

    /*
     * 
     */
    void SpawnEnemy(Transform _enemy)
    {

        // spawn the enemys
        Debug.Log("Spawning enemy, True");

       
        Transform _sp = spawnPoints[ Random.Range(0, spawnPoints.Length) ];
        Instantiate(_enemy, _sp.position, _sp.rotation);

    }// end of Spawn Enemy
    
} //end of WaveSpawner class

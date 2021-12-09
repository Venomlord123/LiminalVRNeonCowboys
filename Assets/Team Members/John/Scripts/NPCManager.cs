using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCManager : MonoBehaviour
{   
    [Tooltip("The list of all available spawns currently not occupied by another NPC")]
    [SerializeField] private static List<Transform> availableSpawns = new List<Transform>();
    [Tooltip("The position to spawn the boss when the boss round is reached")]
    public Transform bossLocation;

    
    //REFERENCES
    [Tooltip("The base enemy that will be spawned within each wave")]
    public GameObject NPC;
    [Tooltip("The boss enemy that will spawn once a boss round is reached")]
    public GameObject Boss;

    public AudioSource npcSpawnSFX;
    public AudioSource npcDeathSFX;

    //VARIABLES
    //private variable for setting location of next spawn
    private int nextSpawn;
    [Tooltip("The number of the current wave")]
    public int waveCount;
    [Tooltip("The number of waves required to be completed in order to trigger the boss encounter")]
    public int bossWave;
    [Tooltip("The base number of enemies to spawn each wave")]
    public int numberToSpawn;
    [Tooltip("The number of extra enemies to spawn with each wave completed. NOTE: This number is compounding with each wave")]
    public int extraEnemies;
    [Tooltip("The amount, in seconds, of time to wait before spawning each enemies within a single wave. Set this to 0 for all enemies to spawn at the same time")]
    public float spawnDelay;
    [Tooltip("The amount, in seconds, of time to wait before starting the next wave")]
    public float waveDelay;
    [Tooltip("The amount, in seconds, of time to wait before starting the boss wave, once it has been reached")]
    public float bossDelay;
    [Tooltip("A list of all the enemies that were spawned in the current wave. Kill each enemy in this list to progress to the next wave")]
    public List<GameObject> remainingEnemies;
    
    public static void AddSpawnPoint(Transform transform)
    {
        availableSpawns.Add(transform);
    }
    public static void RemoveSpawnPoint(Transform transform) => availableSpawns.Remove(transform);

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Spawn());
        }
    }

    public void ReFillSpawns()
    {
        NPC_Spawner[] spawns = GameObject.FindObjectsOfType<NPC_Spawner>();
        foreach (var spawner in spawns)
        {
            availableSpawns.Add(spawner.transform);
        }
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            nextSpawn = Random.Range(0, availableSpawns.Count);
            Transform spawnPoint = availableSpawns.ElementAtOrDefault(nextSpawn);

            if (spawnPoint == null)
            {
                Debug.Log($"Missing spawn point for items at {nextSpawn}");
                yield return null;
            }
            npcSpawnSFX.Play();
            GameObject thisNPC = Instantiate(NPC, spawnPoint.position, spawnPoint.rotation);
            remainingEnemies.Add(thisNPC);
            availableSpawns.RemoveAt(nextSpawn);
            yield return new WaitForSeconds(spawnDelay);
        }

        yield return null;
    }

    public void Die(GameObject thisEnemy)
    {
        npcDeathSFX.Play();
        remainingEnemies.Remove(thisEnemy);
        
        if (thisEnemy.CompareTag("Boss"))
        {
            // Destroy(thisEnemy);
            
            Animator ani = thisEnemy.GetComponent<Animator>();
            ani.SetBool("isDead", true);
            EndGame();
            return;
        }
        Destroy(thisEnemy);

        if (remainingEnemies.Count == 0 && waveCount == bossWave)
        {
            StartCoroutine(BossRound());
            return;
        }
        
        if (remainingEnemies.Count == 0 && waveCount != bossWave)
        {
            StartCoroutine(NextWave());
        }
    }

    public IEnumerator NextWave()
    {
        numberToSpawn = numberToSpawn + extraEnemies;
        waveCount++;
        availableSpawns.Clear();
        ReFillSpawns();
        yield return new WaitForSeconds(waveDelay);
        StartCoroutine(Spawn());
    }

    public IEnumerator BossRound()
    {
        Debug.Log("It's time for a boss battle!");
        yield return new WaitForSeconds(bossDelay);
        npcSpawnSFX.Play();
        Instantiate(Boss, bossLocation.position, bossLocation.rotation);
        var locations = FindObjectsOfType<BossPosition>();
        foreach (var pos in locations)
        {
            pos.gameObject.GetComponent<BossPosition>().AddPoint();
        }
    }

    public void EndGame()
    {
        Debug.Log("Congrats, you beat the boss!");
    }

    public void KillAllNPC()
    {
        for (int i = 0; i < remainingEnemies.Count;)
        {
            remainingEnemies[i].GetComponent<Health>().Damage(remainingEnemies[i].GetComponent<Health>().currentHealth);
        }
    }

    public void KillBoss()
    {
        GameObject boss = GameObject.FindWithTag("Boss");
        if (!boss)
        {
            Debug.Log("Don't be silly, there is no boss here!");
            return;
        }
        boss.GetComponent<Health>().Damage(boss.GetComponent<Health>().currentHealth);
    }

}

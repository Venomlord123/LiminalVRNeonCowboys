using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCManager : MonoBehaviour
{
    private static List<Transform> availableSpawns = new List<Transform>();

    public List<GameObject> remainingEnemies;
    //REFERENCES
    public GameObject NPC;
    public GameObject Boss;
    
    //VARIABLES
    //private variable for setting location of next spawn
    private int nextSpawn;
    //number of the current wave
    public int waveCount;
    //number of rounds to complete to reach the boss
    public int bossWave;
    //number of enemies to spawn in each wave
    public int numberToSpawn;
    //number of extra enemies per wave
    public int extraEnemies;
    //delay between spawning each NPC
    public float spawnDelay;
    
    

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
            GameObject thisNPC = Instantiate(NPC, spawnPoint.position, spawnPoint.rotation);
            remainingEnemies.Add(thisNPC);
            yield return new WaitForSeconds(spawnDelay);
        }

        yield return null;
    }

    public void Die(GameObject thisNPC)
    {
        remainingEnemies.Remove(thisNPC);
        //Destroy(thisNPC);

        if (remainingEnemies.Count == 0 && waveCount != bossWave)
        {
            NextWave();
        }

        if (remainingEnemies.Count == 0 && waveCount == bossWave)
        {
            BossRound();
        }
    }

    public void NextWave()
    {
        numberToSpawn = numberToSpawn + extraEnemies;
        waveCount++;
        StartCoroutine(Spawn());
    }

    public void BossRound()
    {
        //spawn the boss and do the cool stuff
        Debug.Log("It's time for a boss battle!");
    }
    
}

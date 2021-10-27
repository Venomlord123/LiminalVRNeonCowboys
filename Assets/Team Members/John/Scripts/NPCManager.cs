using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCManager : MonoBehaviour
{
    public static List<Transform> availableSpawns = new List<Transform>();

    public List<NPC> remainingEnemies;

    public GameObject NPC;

    public GameObject Boss;

    public int nextSpawn;

    public int waveCount;
    public float waveDelay;
    
    

    public static void AddSpawnPoint(Transform transform)
    {
        availableSpawns.Add(transform);
    }
    public static void RemoveSpawnPoint(Transform transform) => availableSpawns.Remove(transform);

    private void Start()
    {
        SpawnNPC();
    }

    void SpawnNPC()
    {
        for (int i = 0; i < waveCount; i++)
        {
            nextSpawn = Random.Range(0, availableSpawns.Count);
            Transform spawnPoint = availableSpawns.ElementAtOrDefault(nextSpawn);

            if (spawnPoint == null)
            {
                Debug.Log($"Missing spawn point for items at {nextSpawn}");
                return;
            }

            Instantiate(NPC, spawnPoint.position, spawnPoint.rotation);
        }

    }
}

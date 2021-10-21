using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void SpawnNPC()
    {
        //do the spawn thing ya feel...
    }
}

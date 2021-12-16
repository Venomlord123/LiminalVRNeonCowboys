using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    //public void Awake() => NPCManager.AddSpawnPoint(transform);
    
   // private void OnDestroy() => NPCManager.RemoveSpawnPoint(transform);

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.25f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + transform.forward * 2);
    }
}

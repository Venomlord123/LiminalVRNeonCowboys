using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NPCManager))]
public class NPCEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Kill All Enemies"))
        {
            (target as NPCManager)?.KillAllNPC();
        }

        if (GUILayout.Button("Kill The Boss \n (Only Click If Boss Has Spawned)"))
        {
            (target as NPCManager)?.KillBoss();
        }
    }
}

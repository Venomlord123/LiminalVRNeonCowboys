using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public NPCManager NpcManager;
    public SoundManager soundManager;
    public float startDelay;
    // Start is called before the first frame update
    void Start()
    {
        NpcManager = FindObjectOfType<NPCManager>();
        StartCoroutine(FirstWave());
    }

    public IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(NpcManager.Spawn());
        soundManager.PlayOST();
    }

}

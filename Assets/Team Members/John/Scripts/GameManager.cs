using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public NPCManager NpcManager;
    public SoundManager soundManager;
    public float startDelay;
    public float introTextTime;
    public GameObject introText;
    // Start is called before the first frame update
    void Start()
    {
        NpcManager = FindObjectOfType<NPCManager>();
        StartCoroutine(IntroText());
        StartCoroutine(FirstWave());
    }

    public IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(NpcManager.Spawn());
        soundManager.PlayOST();
    }

    public IEnumerator IntroText()
    {
        yield return new WaitForSeconds(introTextTime);
        introText.SetActive(false);
    }

}

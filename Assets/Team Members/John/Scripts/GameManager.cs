using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public GunHolder gunHolder;
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

    private void Update()
    {
        if (NpcManager.gameEnded)
        {
            StartCoroutine(FadeOut());
        }
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
        gunHolder.EnableGuns();
        introText.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        var fade = ScreenFader.Instance;
        fade.FadeToBlack(2f);
        yield return new WaitForSeconds(2f);
        ExperienceApp.End();
    }

}

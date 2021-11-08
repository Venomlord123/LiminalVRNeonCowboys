using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource OST;

    public void PlayOST()
    {
        OST.Play();
    }

    public void StopOST()
    {
        OST.Stop();
    }
}

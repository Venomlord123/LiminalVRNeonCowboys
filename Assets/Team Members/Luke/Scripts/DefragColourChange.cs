using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DefragColourChange : MonoBehaviour
{
    public List<GameObject> greenBlueMats;
    public List<GameObject> redWhiteMats;
    public float greenBlueChangeTimeMax;
    public float greenBlueChangeTimeMin;
    public float redWhiteChangeTimeMax;
    public float redWhiteChangeTimeMin;

    private void Start()
    {
        StartCoroutine(ColourChangeGreenBlue());
        StartCoroutine(ColourChangeRedWhite());
    }

    public IEnumerator ColourChangeGreenBlue()
    {
        foreach (GameObject obj in greenBlueMats)
        {
            Material mat = obj.GetComponent<MeshRenderer>().material;

            if (mat.color == Color.green)
            {
                mat.SetColor("_EmissionColor", Color.blue);
                mat.color = Color.blue;
            }
            else
            {
                mat.SetColor("_EmissionColor", Color.green);
                mat.color = Color.green;
            }
            yield return new WaitForSeconds(Random.Range(greenBlueChangeTimeMin,greenBlueChangeTimeMax));
        }

        StartCoroutine(ColourChangeGreenBlue());
    }

    public IEnumerator ColourChangeRedWhite()
    {
        foreach (GameObject obj in redWhiteMats)
        {
            Material mat = obj.GetComponent<MeshRenderer>().material;

            if (mat.color == Color.red)
            {
                mat.SetColor("_EmissionColor", Color.white);
                mat.color = Color.white;
            }
            else
            {
                mat.SetColor("_EmissionColor", Color.red);
                mat.color = Color.red;
            }
            yield return new WaitForSeconds(Random.Range(redWhiteChangeTimeMin,redWhiteChangeTimeMax));
            if (mat.color == Color.red)
            {
                mat.SetColor("_EmissionColor", Color.white);
                mat.color = Color.white;
            }
            else
            {
                mat.SetColor("_EmissionColor", Color.red);
                mat.color = Color.red;
            }
        }

        StartCoroutine(ColourChangeRedWhite());
    }
}

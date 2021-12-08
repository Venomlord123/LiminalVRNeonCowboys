using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlay : MonoBehaviour
{
    public RawImage image;
    public float damageViewTime;
    public bool isFading;
    public float fadeoutTime;

    // Start is called before the first frame update
    private void Start()
    {
        image.canvasRenderer.SetAlpha(0f);
    }

    private void Update()
    {
        if (isFading)
        {
            if (fadeoutTime >= 0f)
            {
                fadeoutTime -= Time.deltaTime;
                image.canvasRenderer.SetAlpha(fadeoutTime);
                if (fadeoutTime <= 0f)
                {
                    image.canvasRenderer.SetAlpha(0f);
                    isFading = false;
                    fadeoutTime = 0.25f;
                }
            }
        }
    }

    public void Shot()
    {
        GetComponentInParent<AudioSource>().Play();
        image.canvasRenderer.SetAlpha(.25f);
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(damageViewTime);
        isFading = true;
    }
}
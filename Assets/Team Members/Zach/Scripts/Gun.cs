using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Object Pooling Variables
    public static Gun SharedInstance;
    public List<GameObject> bullets;
    public GameObject laser;
    public int amountToPool;
    //Variables
    public float fireRate;
    public AudioSource gunSFX;
    public AudioSource deflectionSFX;
    public bool isRight;
    public bool isLeft;
    private float nextFire;
    public List<MeshRenderer> meshRenderers;
    public Color colour;

    public void Start()
    {
        SharedInstance = this;
        
        bullets = new List<GameObject>();
        GameObject tempBullet;
        for (int i = 0; i < amountToPool; i++)
        {
            tempBullet = Instantiate(laser);
            tempBullet.SetActive(false);
            bullets.Add(tempBullet);
        }
    }

    public void ColourChanging()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            deflectionSFX.Play();
            colour = meshRenderer.material.GetColor("_EmissionColor");
            meshRenderer.material.SetColor("_EmissionColor", Color.white);
            StartCoroutine(ColourChangeTime());
        }
    }

    public IEnumerator ColourChangeTime()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.SetColor("_EmissionColor", colour);
        }
    }

    public void Update()
    {
        if (isRight)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) >= 0.1f &&
                Time.time > nextFire)
            {
                GameObject laser = SharedInstance.GetPooledObject();
                if (laser != null)
                {
                    nextFire = Time.time + fireRate;
                    laser.transform.position = transform.position;
                    laser.transform.rotation = transform.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
            }
        }

        if (isLeft)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) >= 0.1f &&
                Time.time > nextFire)
            {
                GameObject laser = SharedInstance.GetPooledObject();
                if (laser != null)
                {
                    nextFire = Time.time + fireRate;
                    laser.transform.position = transform.position;
                    laser.transform.rotation = transform.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }

        return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<NPCBullet>())
        {
            other.gameObject.SetActive(false);
        }
    }
}
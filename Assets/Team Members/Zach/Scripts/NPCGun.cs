using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class NPCGun : MonoBehaviour
{
    //Object Pooling Variables
    public static NPCGun SharedInstance;
    public List<GameObject> lasers;
    public GameObject laser;
    public int amountToPool;
    //Variables
    public float timeTillShoot;
    public float shootTime;
    public bool canShoot;
    public Transform playerLocation;
    public AudioSource gunSFX;
    
    
    public void Awake()
    {
        SharedInstance = this;
        playerLocation = FindObjectOfType<VRAvatarHead>().GetComponent<Transform>();
        canShoot = true;
    }
    
    public void Start()
    {
        lasers = new List<GameObject>();
        GameObject tempBullet;
        for (int i = 0; i < amountToPool; i++)
        {
            tempBullet = Instantiate(laser);
            tempBullet.SetActive(false);
            lasers.Add(tempBullet);
        }

        timeTillShoot = shootTime;
    }


    public void Update()
    {
        timeTillShoot -= Time.deltaTime;

        gameObject.transform.LookAt(playerLocation);
        
        if (timeTillShoot <= 0 && canShoot)
        {
            canShoot = false;
            GameObject laser = SharedInstance.GetPooledObject();
            if (laser != null)
            {
                laser.transform.position = transform.position;
                laser.transform.rotation = transform.rotation;
                laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                laser.SetActive(true);
                gunSFX.Play();
            }

            timeTillShoot = shootTime;
            canShoot = true;
        }
        
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!lasers[i].activeInHierarchy)
            {
                return lasers[i];
            }
        }

        return null;
    }
}

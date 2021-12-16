using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [Header("Object Pooling Variables")] 
    public static BossWeapon Instance;
    public List<GameObject> bossLasers = new List<GameObject>();
    public GameObject laserPrefab;
    public GameObject laserToShoot;
    public int poolAmount;
    
    [Header("Gun Behaviour Variables")] 
    private Transform playerTrarget;
    public Transform firePoint;
    public NPC _Npc;
    public int shotDelay;
    public AudioSource gunSFX;
    public float chanceToShoot;
    public bool shooting;

    private void Start()
    {
        Instance = this;
        GameObject tempBossLaser;
        for (int i = 0; i < poolAmount; i++)
        {
            tempBossLaser = Instantiate(laserPrefab);
            tempBossLaser.SetActive(false);
            bossLasers.Add(tempBossLaser);
        }
        playerTrarget = FindObjectOfType<Target>().GetComponent<Transform>();
        gameObject.transform.LookAt(playerTrarget);
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (shooting)
        {
            laserToShoot = null;
            laserToShoot = Instance.GetPooledObject();
            if (laserToShoot != null)
            {
                if (bossLasers.Contains(laserToShoot))
                {
                    laserToShoot.transform.position = firePoint.position;
                    laserToShoot.transform.rotation = firePoint.rotation;
                    laserToShoot.GetComponent<Rigidbody>().AddForce(_Npc.directionToTarget);
                    laserToShoot.SetActive(true);
                    gunSFX.Play();
                    GetComponentInChildren<Animator>().Play("Attack2");
                }
            }
            Debug.Log("Restarting");
            yield return new WaitForSeconds(shotDelay);
        }
        
    }

    private GameObject GetPooledObject()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!bossLasers[i].activeInHierarchy)
            { 
                return bossLasers[i];
            }
            
        }
        return null;
    }
}

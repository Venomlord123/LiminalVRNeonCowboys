using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class NPCGun : MonoBehaviour
{
    //Object Pooling Variables
    public static NPCGun SharedInstance;
    public List<GameObject> straightLasers;
    public List<GameObject> longLasers;
    public GameObject straightLaser;
    public GameObject longLaser;
    public int amountToPool;


    //Variables
    public float timeTillShoot;
    public float shootTime;
    public float chanceToShoot;
    public bool canShoot;
    public Transform playerLocation;
    public AudioSource gunSFX;
    private Animator animator;


    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        SharedInstance = this;
        playerLocation = FindObjectOfType<VRAvatarHead>().GetComponent<Transform>();
        canShoot = true;
    }

    public void Start()
    {
        straightLasers = new List<GameObject>();
        GameObject tempStraightLaser;
        for (int i = 0; i < amountToPool; i++)
        {
            tempStraightLaser = Instantiate(straightLaser);
            tempStraightLaser.SetActive(false);
            straightLasers.Add(tempStraightLaser);
        }

        longLasers = new List<GameObject>();
        GameObject tempLongLaser;
        for (int i = 0; i < amountToPool; i++)
        {
            tempLongLaser = Instantiate(longLaser);
            tempLongLaser.SetActive(false);
            longLasers.Add(tempLongLaser);
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
                animator.Play("Attack");
                laser.transform.position = transform.position;
                if (longLasers.Contains(laser))
                {
                    laser.transform.rotation = transform.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
                else
                {
                    laser.transform.rotation = transform.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
            }

            timeTillShoot = shootTime;
            canShoot = true;
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            float chance = Random.Range(0f, 1f);
            if (chance >= chanceToShoot)
            {
                if (!straightLasers[i].activeInHierarchy)
                {
                    return straightLasers[i];
                }
            }
            else
            {
                if (!longLasers[i].activeInHierarchy)
                {
                    return longLasers[i];
                }
            }
        }

        return null;
    }
}
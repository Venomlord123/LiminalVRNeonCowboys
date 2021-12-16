using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class NPCGun : MonoBehaviour
{
    //Object Pooling Variables
    public static NPCBulletPool SharedInstance;
    public int amountToPool;


    //Variables
    public float timeTillShoot;
    public float shootTime;
    public float chanceToShoot;
    public bool canShoot;
    public Transform playerLocation;
    public NPC npc;
    public AudioSource gunSFX;
    private Animator animator;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SharedInstance = FindObjectOfType<NPCBulletPool>();
        playerLocation = FindObjectOfType<Target>().GetComponent<Transform>();
        canShoot = true;
        
        timeTillShoot = shootTime;
    }


    public void Update()
    {
        timeTillShoot -= Time.deltaTime;

        gameObject.transform.LookAt(playerLocation);

        if (timeTillShoot <= 0 && canShoot)
        {
            canShoot = false;
            GameObject laser = SharedInstance.GetPooledObject(chanceToShoot);
            if (laser != null)
            {
                animator.Play("Attack");
                laser.transform.position = npc.NPCFirePoint.position;
                if (SharedInstance.longLasers.Contains(laser))
                {
                    laser.transform.rotation = npc.NPCFirePoint.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
                else
                {
                    laser.transform.rotation = npc.NPCFirePoint.rotation;
                    laser.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    laser.SetActive(true);
                    gunSFX.Play();
                }
            }

            timeTillShoot = shootTime;
            canShoot = true;
        }
    }
  
}
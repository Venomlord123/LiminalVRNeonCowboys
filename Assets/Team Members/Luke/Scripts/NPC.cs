using System;
using System.Collections;
using Liminal.SDK.VR.Avatars;
using UnityEngine;
using Random = UnityEngine.Random;


public class NPC : MonoBehaviour
{
    [Tooltip("The position from which the NPC is able to fire a bullet")]
    public Transform NPCFirePoint;
    public Transform playerTarget;
    private Vector3 shotTarget;
    [Tooltip("The percentage chance for the NPC to miss the player")]
    public float chanceToHit;
    [Tooltip("The amount to offset the NPC's target in the X value only. This value will apply to both negative and positive variance")]
    public int xVariance;
    [Tooltip("The amount to offset the NPC's target in the Y value only. This value will apply to both negative and positive variance")]
    public int yVariance;
    public Vector3 directionToTarget;
    [Tooltip("The amount of time, in seconds, that the NPC should wait before firing each shot")]
    public float shotDelay;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerTarget = FindObjectOfType<VRAvatar>().GetComponentInChildren<Target>().transform;
    }

    void Update()
    {
        directionToTarget = (playerTarget.position - transform.position).normalized;

         var chanceCheck =  Random.Range(min: 0f, max: 100f);
        //WORK ON THIS BECAUSE YOU SUCK AT MATH
        if (chanceCheck > chanceToHit)
        { 
            var offset = new Vector3(Random.Range(-xVariance, xVariance), Random.Range(-yVariance, yVariance), 0);
            shotTarget = playerTarget.position + offset;
        }

        NPCFirePoint.transform.LookAt(shotTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(NPCFirePoint.position,shotTarget);
    }

    public IEnumerator Shooting()
    {
        //Todo Do we make the decision on laser type???
        //reference to gun
        //raycast from npc arm to player.transform then gun.shoot
        yield return new WaitForSeconds(shotDelay);
    }

    public void LaserChoice()
    {
        //random range set to be nextBullet
    }
}

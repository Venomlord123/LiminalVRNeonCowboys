using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //References
    //gun or guns
    //health
    //User

    //Variables
    public float shotDelay;
    //public gameobject laser1 
    // laser2
    public int nextBullet;
    public Transform player;
    public Transform npcArm;

    private void Awake()
    {
        //reference to guns to getComponent GameObject laser1 & laser2
    }
    
    // Update is called once per frame
    void Update()
    {
        
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

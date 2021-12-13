﻿using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    public Vector3 holdPos;
    public Transform targetPos;
    public float distance;
    public float holdSpeed;
    public float attackSpeed;
    public bool holding;
    public bool attacking;

    public int damageAmount;

    private void Awake()
    {
        holding = false;
        attacking = false;
        targetPos = FindObjectOfType<VRAvatar>().GetComponentInChildren<Target>().transform;
    }

    public void SetHoldPos(Vector3 vector)
    {
        holdPos = vector;
    }

    private void Update()
    {
        if (!holding)
        {
            transform.position = Vector3.MoveTowards(transform.position,holdPos,holdSpeed);
            distance = Vector3.Distance(transform.position, holdPos);
            if (distance <= 1f)
            {
                holding = true;
                attacking = true;
            }
        }

        if (attacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, attackSpeed);
            distance = Vector3.Distance(transform.position, targetPos.position);
            if (distance <= 1f)
            {
                gameObject.SetActive(false);
            }
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<Gun>())
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponentInParent<VRAvatar>().gameObject.GetComponentInChildren<Gun>().ColourChanging();
        }

        else if (other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>())
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>().Shot();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class NPCBulletLong : MonoBehaviour
{
    public Rigidbody rb;

    //todo set this properly when doing polling
    //Set this before playing in scene
    public float speed;
    public float time;
    public float scaleSpeed;
    public float lifeTime;
    public Vector3 originalScale;
    public Vector3 maxScale;

    public int damage;
    public Vector3 tranfromScale;


    public void Awake()
    {
        originalScale = transform.localScale;
        tranfromScale = transform.localScale;
    }

    private void Update()
    {
        time = time + Time.deltaTime;
        if (time >= lifeTime)
        {
            gameObject.SetActive(false);
        }
        
        if (tranfromScale.x <= maxScale.x)
        {
            transform.localScale += new Vector3(1f,0,0) * Time.deltaTime * scaleSpeed;
            tranfromScale = transform.localScale;
        }
    }
    
    //TODO Make the bullet scale over time instead of instantly using maybe a IEnumerator
    
    public void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
    }

    public void OnDisable()
    {
        time = 0;
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = originalScale;
        tranfromScale = originalScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<VRAvatar>())
        {
            gameObject.SetActive(false);
            other.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>().Shot();
        }
    }
}
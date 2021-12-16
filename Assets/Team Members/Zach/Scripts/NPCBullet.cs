using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.Extensions;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class NPCBullet : MonoBehaviour
{
    public Rigidbody rb;

    //todo set this properly when doing polling
    //Set this before playing in scene
    public float speed;
    public float time;
    public float lifeTime;

    public int damage;


    private void Update()
    {
        time = time + Time.deltaTime;
        if (time >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
        Debug.Log("bullet firing");
    }

    public void OnDisable()
    {
        time = 0;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CenterEye")
        {
            if (other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>())
            {
                gameObject.SetActive(false);
                other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>().Shot();
            }
        }
        else if (other.gameObject.name == "Cannon1")
        {
            if(other.gameObject == other.GetComponentInParent<GunHolder>().gunMeshes[0])
            {
                gameObject.SetActive(false);
                other.gameObject.GetComponentInParent<GunHolder>().guns[0].GetComponent<Gun>().ColourChanging();
            }
            
        }
        else if (other.gameObject.name == "Cannon2")
        { 
            if (other.gameObject == other.GetComponentInParent<GunHolder>().gunMeshes[1])
            {
                gameObject.SetActive(false);
                other.gameObject.GetComponentInParent<GunHolder>().guns[1].GetComponent<Gun>().ColourChanging();
            }
        }
        else
        {
            if (other.gameObject.transform.CompareTag("NPC"))
            {
                gameObject.SetActive(true);
            }
            else if(other.gameObject.transform.CompareTag("Missile"))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}

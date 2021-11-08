using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.Extensions;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    //todo set this properly when doing polling
    //Set this before playing in scene
    public float speed;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(-transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.HasComponent<NPC>())
        {
            other.GetComponent<Health>().Damage(1);
        }
    }
}

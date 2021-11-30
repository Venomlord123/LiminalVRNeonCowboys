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
    }

    public void OnDisable()
    {
        time = 0;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Health>() != null)
        {
            other.gameObject.GetComponentInParent<Health>().Damage(1);
        }
    }
}

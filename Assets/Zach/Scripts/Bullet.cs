using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    //todo set this properly when doing polling
    //Set this before playing in scene
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed);
    }
}

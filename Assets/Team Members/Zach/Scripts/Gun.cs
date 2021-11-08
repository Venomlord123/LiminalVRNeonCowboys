using System;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float triggerFloat;
    public Transform bulletSpawnPos;
    public float fireRate;
    private float nextFire = 0f;
    public AudioSource gunSFX;

    public void Update()
    {
        triggerFloat = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) >= 0.1f && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawnPos.position, transform.rotation);
            gunSFX.Play();
        }
    }
}

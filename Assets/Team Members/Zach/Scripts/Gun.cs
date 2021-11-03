using System;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float triggerFloat;

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        triggerFloat = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) >= 0.1f)
        {
            Instantiate(bullet, transform.position, new Quaternion());
        }
    }
}

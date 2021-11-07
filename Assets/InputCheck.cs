using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class InputCheck : MonoBehaviour
{
    IVRDevice device;
    IVRInputDevice rightHand;
    IVRInputDevice leftHand;

    void Start()
    {
        device = VRDevice.Device;
        rightHand = device.PrimaryInputDevice;
        leftHand = device.SecondaryInputDevice;
    }

    private void Update()
    {
        //successful print of debug on trigger pull (VIVE)
        if (rightHand.GetButtonDown(VRButton.Trigger))
        {
            Debug.Log("The trigger is pulled");
        }
        
    }
}


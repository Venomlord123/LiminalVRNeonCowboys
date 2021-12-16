using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR.Avatars;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector3 _rotation;
    public float _speed;

    private void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
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
            if (other.gameObject.transform.CompareTag("Boss"))
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

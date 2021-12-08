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
        if (other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>())
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponentInParent<VRAvatar>().GetComponentInChildren<DamageOverlay>().Shot();
        }
    }
}

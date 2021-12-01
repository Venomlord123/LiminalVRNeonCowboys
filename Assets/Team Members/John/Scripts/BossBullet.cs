using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector3 _rotation;
    public float _speed;

    private void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}

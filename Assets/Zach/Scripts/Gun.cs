using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bullet, transform.position, new Quaternion());
        }
    }
}

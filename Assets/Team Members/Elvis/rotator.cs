using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
   public float rotationSpeedY;
    public float rotationSpeedX;
    public float rotationSpeedZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
    }
}

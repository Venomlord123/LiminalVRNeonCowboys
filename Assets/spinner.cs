using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
   public float  rotationDirection;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 45f, 0f) * Time.deltaTime *rotationDirection);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMovement : MonoBehaviour
{
    
    [SerializeField] private static List<Transform> positions = new List<Transform>();
    public Transform center;
    public float moveSpeed;
    public Transform movePos;
    public bool moving;
    public bool centering;
    public bool atCenter;
    public float distance;

    private void Awake()
    {
        center.position = transform.position;
        atCenter = true;
        moving = false;
        centering = false;
        
        StartCoroutine(Moving());
    }
    
    public static void AddPoint(Transform transform)
    {
        positions.Add(transform);
    }

    public IEnumerator Moving()
    {
        while (true)
        {
            if (atCenter)
            {
                var selected = Random.Range(1, 2);
                movePos = positions[selected];
                moving = true;
                atCenter = false;
            }

            if (moving)
            {
                transform.position = Vector3.MoveTowards(transform.position,movePos.position,moveSpeed);
                distance = Vector3.Distance(transform.position, movePos.position);
                if (distance <= 1f)
                {
                    centering = true;
                    moving = false;
                }
            }

            if (centering)
            {
                transform.position = Vector3.MoveTowards(transform.position, center.position, moveSpeed);
                distance = Vector3.Distance(transform.position, center.position);
                if (distance <= 1f)
                {
                    centering = false;
                    atCenter = true;
                }
            }
        }
    }

    private void Update()
    {
        Debug.Log("Wow Really Moving");
    }
}

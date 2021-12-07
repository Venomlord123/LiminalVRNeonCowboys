﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    //int index
    int NextPosIndex;
    Transform NextPos;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    // function for moving  cubes on grid
    void MoveGameObject()
    {
        if (transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        }
    }
}

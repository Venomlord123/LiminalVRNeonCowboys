using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBulletPool : MonoBehaviour
{
    public List<GameObject> straightLasers;
    public List<GameObject> longLasers;
    public GameObject straightLaser;
    public GameObject longLaser;
    public int amountToPool;

    void Start()
    {
        straightLasers = new List<GameObject>();
        GameObject tempStraight;
        for (int i = 0; i < amountToPool; i++)
        {
            tempStraight = Instantiate(straightLaser);
            tempStraight.SetActive(false);
            straightLasers.Add(tempStraight);
        }
        longLasers = new List<GameObject>();
        GameObject tempLong;
        for (int i = 0; i < amountToPool; i++)
        {
            tempLong = Instantiate(longLaser);
            tempLong.SetActive(false);
            longLasers.Add(tempLong);
        }
    }
    
    public GameObject GetPooledObject(float chanceToShoot)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            float chance = Random.Range(0f, 1f);
            if (chance >= chanceToShoot)
            {
                if (!straightLasers[i].activeInHierarchy)
                {
                    return straightLasers[i];
                }
            }
            else
            {
                if (!longLasers[i].activeInHierarchy)
                {
                    return longLasers[i];
                }
            }
        }

        return null;
    }
}

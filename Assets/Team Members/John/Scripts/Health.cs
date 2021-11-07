using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public NPCManager manager;

    private void Awake()
    {
        currentHealth = startingHealth;
        manager = FindObjectOfType<NPCManager>();
    }
    
    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        
        if (currentHealth == 0)
        {
            manager.Die(gameObject);
        }
    }

    
}
